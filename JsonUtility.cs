using System;
using System.IO;
using System.Text;
using System.Collections;

namespace Grimoire
{
	#if NET20 || NET40
	using IListG = System.Collections.Generic.IList<object>;
	using IStringObjectDictionaryG = System.Collections.Generic.IDictionary<string,object>;
	using ICharEnumerableG = System.Collections.Generic.IEnumerable<char>;
	using ICharEnumeratorG = System.Collections.Generic.IEnumerator<char>;
	using ListG = System.Collections.Generic.List<object>;
	using StringObjectDictionaryG = System.Collections.Generic.Dictionary<string,object>;
	using StringObjectPairG = System.Collections.Generic.KeyValuePair<string,object>;
	#endif

	// simple, fast dependency free JSON parser - alpha candidate rev b.
	// uses only the core JSON types (string/number/null/boolean/object/array)

	// note that we support a slightly extended JSON syntax. A key to an object can either be a
	// string, which is standard, or it can be an identifer. An identifier starts with a letter
	// or an underscore. The remaining characters can be a letter, a digit, an underscore, or a
	// hyphen. So it's the same as a C# identifier, but allows also for embedded hyphens.
	// the result is slightly more readable json input. The code will *never* output this model
	// and this only applies to object field names. {"left-hand":1} and {left-hand:1} are equivelant

	public sealed 
	#if NET20 || NET40
	partial
	#endif 
	class JsonUtility
	{
		private sealed class TextReaderEnumerator : 
		#if NET20 || NET40
		ICharEnumeratorG 
		#else
		IEnumerator,IDisposable
		#endif
		{
			int _current=-1;
			readonly TextReader _reader;
			public TextReaderEnumerator(TextReader reader) {_reader = reader;}
			public char Current {
				get { 
					if (-1 == _current)
						throw new InvalidOperationException ("Enumerator is not on data.");
					return (char)_current;
				}
			}
			object IEnumerator.Current { get {return Current;}}
			public bool MoveNext() {
				_current = _reader.Read ();
				return -1 != _current;
			}
			public void Dispose() {
				_reader.Dispose ();
			}
			void IEnumerator.Reset() {throw new NotSupportedException ();}
		}
		
		#if !NET20 && !NET40
		private JsonUtility () {}
		#endif

		#if NET20 || NET40
		public static ListG ParseArray (ICharEnumeratorG e)
		{
			if ('[' != e.Current)
				return null;
			if (!e.MoveNext ())
				throw new InvalidOperationException ("JSON array unterminated.");
			ListG result = new ListG ();
			SkipWhitespace (e);
			char ch = e.Current;
			if (',' == ch)
				throw new InvalidOperationException ("JSON array contains empty element");
			if (']' == ch) {
				e.MoveNext ();
				return result;
			}
			while (true) {
				result.Add (Parse (e));
				SkipWhitespace (e);
				ch = e.Current;
				switch (ch) {
				case ']':
					e.MoveNext ();
					return result;
				case ',':
					if (!e.MoveNext ())
						throw new InvalidOperationException ("JSON array unterminated.");
					break;
				default:
					throw new InvalidOperationException ("Unexpected character in JSON array.");
				}
				SkipWhitespace (e);
			}
		}

		public static StringObjectDictionaryG ParseObject (ICharEnumeratorG e)
		{
			if ('{' != e.Current)
				return null;
			if (!e.MoveNext ())
				throw new InvalidOperationException ("JSON object unterminated.");
			StringObjectDictionaryG result = new StringObjectDictionaryG ();
			SkipWhitespace (e);
			char ch = e.Current;
			if (',' == ch)
				throw new InvalidOperationException ("JSON object contains empty element");
			if ('}' == ch) {
				e.MoveNext ();
				return result;
			}
			while (true) {
				string key = ParseString (e);
				if (null == key) 
					key = ParseIdentifier (e);
				if (null == key) 
					throw new InvalidOperationException ("Could not parse key in JSON object");
				
				SkipWhitespace (e);
				ch = e.Current;
				if (':' != ch || !e.MoveNext ())
					throw new InvalidOperationException ("Could not parse value in JSON object");
				SkipWhitespace (e);
				object value = Parse (e);
				SkipWhitespace (e);
				result.Add (key, value);
				ch = e.Current;
				switch (ch) {
				case '}':
					e.MoveNext ();
					return result;
				case ',':
					if (!e.MoveNext ())
						throw new InvalidOperationException ("JSON object unterminated.");
					break;
				default:
					throw new InvalidOperationException ("Unexpected character in JSON array.");
				}
				SkipWhitespace (e);
			}
		}

		private static void ParseCombineDigits (ICharEnumeratorG e, int part, ref double accumulator)
		{
			// combines accumulating numberic values and parsing into one operation.
			// part indicates which form we're processing
			// 0 indicates a series of digits will be interpreted as a positive integral value - ex: "123" will result in a double precision value of 123
			// 1 indicates a series of digits will be interpreted as a fractional value - ex: "123" will result in a double precision value of .123
			// in both of the above cases, the parsed value will be added to the accumlator value

			// 2 indicates a series of digits will be interpreted as a positive exponent value. the accumulator contains the input value and the next string indicates the expononent such that 1.2E3 would mean 1.2 was passed as the accumulated value, and here we're about to parse '3'. The accumulator will have the exponent multiplicand (1000) applied here. 
			// 3 indicates a series of digits will be interpreted as a positive exponent value. the accumulator contains the input value and the next string indicates the expononent such that 1.2E-3 would mean 1.2 was passed as the accumulated value, and here we're about to parse '3'. The accumulator will have the exponent divisor (1000) applied here. 

			char ch = e.Current;
			if (!(ch >= '0' && ch <= '9'))
				return;
			double result = 0.0d;
			double count;
			long exp;
			switch (part) {
			case 1: // frac part
				count = 1d;
				while (ch >= '0' && ch <= '9') {
					result *= 10;
					count *= .1;
					result += (int)(ch - '0');

					if (!e.MoveNext ())
						break;
					ch = e.Current;
				}
				accumulator += (result * count);
				return;
			case 2: // E(+) part
				if ('0' == ch)
					throw new InvalidOperationException ("Invalid JSON Number."); // exp can't have a leading zero.
				exp = 0;
				while (ch >= '0' && ch <= '9') {
					exp *= 10;
					exp += (int)(ch - '0');
					if (!e.MoveNext ())
						break;
					ch = e.Current;
				}
				accumulator *= Math.Pow (10, exp);
				return;
			case 3: // E- part
				if ('0' == ch)
					throw new InvalidOperationException ("Invalid JSON Number."); // exp can't have a leading zero.
				exp = 0;
				while (ch >= '0' && ch <= '9') {
					exp *= 10;
					exp += (int)(ch - '0');
					if (!e.MoveNext ())
						break;
					ch = e.Current;
				}
				accumulator /= Math.Pow (10, exp);
				return;

			default: // 0 - standard integer part.
				while (ch >= '0' && ch <= '9') {
					result *= 10;
					result += (int)(ch - '0');
					if (!e.MoveNext ())
						break;
					ch = e.Current;
				}
				accumulator += result;
				return; 
			}
		}

		public static double ParseNumber (ICharEnumeratorG e)
		{

			bool neg = false;
			char ch = e.Current;
			if ('-' == ch) { // handle leading '-'
				if (!e.MoveNext ())
					throw new InvalidOperationException ("Invalid JSON Number"); // '-' at the end of the input
				neg = true;
				ch = e.Current;

			}
			if ('0' == ch) {
				if (!e.MoveNext ()) {
					if (neg)
						throw new InvalidOperationException ("Invalid JSON Number"); // -0{EOS} invalid
					return 0.0d;
				}
				ch = e.Current;
				if (ch != '.') {
					if (neg || (ch >= '0' && ch <= '9')) // -0 or 0{digits} invalid;
						throw new InvalidOperationException ("Invalid JSON Number");
					return 0.0d;
				}
			}
			double result = 0.0d;
			ch = e.Current;

			if (ch >= '0' && ch <= '9') {
				ParseCombineDigits (e, 0, ref result); // shouldn't return false.
				ch = e.Current;
			}
			if (ch == '.') {
				if (!e.MoveNext ())
					throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}.{EOS}

				ch = e.Current;
				if (ch < '0' || ch > '9') // invalid {result}.[^0-9]
					throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}.{EOS}
				ParseCombineDigits (e, 1, ref result);
				ch = e.Current;
			}
			if (ch == 'e' || ch == 'E') {
				if (!e.MoveNext ())
					throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}[Ee]{EOS}
				ch = e.Current;
				int s = 2;
				if (ch == '+') {
					if (!e.MoveNext ())
						throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}[Ee]+{EOS}
					ch = e.Current;
				} else if (ch == '-') {
					s = 3;
					if (!e.MoveNext ())
						throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}[Ee]-{EOS}
					ch = e.Current;
				}
				if (ch < '0' || ch > '9') // invalid {result}[^0-9]
					throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}[^0-9]
				ParseCombineDigits (e, s, ref result);
			}
			if (neg)
				result = -result;
			return result;
		}

		public static object Parse (ICharEnumerableG @json)
		{
			using (ICharEnumeratorG e = @json.GetEnumerator ()) {
				if (e.MoveNext ()) {
					return Parse (e);
				}
				throw new InvalidOperationException ("JSON value empty.");
			}
		}

		public static object Parse (ICharEnumeratorG e)
		{
			SkipWhitespace (e);
			char ch = e.Current;
			switch (ch) {
			case 't':
				if (!e.MoveNext () ||
				    'r' != e.Current || !e.MoveNext () ||
				    'u' != e.Current || !e.MoveNext () ||
				    'e' != e.Current || (e.MoveNext () &&
				    char.IsLetterOrDigit (e.Current)))
					goto default;
				return true;
			case 'f':
				if (!e.MoveNext () ||
				    'a' != e.Current || !e.MoveNext () ||
				    'l' != e.Current || !e.MoveNext () ||
				    's' != e.Current || !e.MoveNext () ||
				    'e' != e.Current || (e.MoveNext () &&
				    char.IsLetterOrDigit (e.Current)))
					goto default;
				return false;
			case 'n':
				if (!e.MoveNext () ||
				    'u' != e.Current || !e.MoveNext () ||
				    'l' != e.Current || !e.MoveNext () ||
				    'l' != e.Current || (e.MoveNext () &&
				    char.IsLetterOrDigit (e.Current)))
					goto default;
				return null;				
			case '[':
				ListG al = ParseArray (e);
				return al;
			case '{':
				StringObjectDictionaryG ht = ParseObject (e);
				return ht;
			case '\"':
				goto case '\'';
			case '\'':
				return ParseString (e);
			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return ParseNumber (e);
			default:
				throw new InvalidOperationException ("JSON value invalid.");
			}

		}
		public static string ParseIdentifier (ICharEnumeratorG e)
		{
			char ch = e.Current;
			if ('_'!=ch && !char.IsLetter (ch))
				return null;
			StringBuilder sb = new StringBuilder (); 
			sb.Append (ch);
			while (e.MoveNext ()) {
				ch = e.Current;
				if (!('_' == ch || '-' == ch || char.IsLetterOrDigit (ch)))
					break;
				sb.Append (ch);
			}
			if (':' != ch)
				throw new InvalidOperationException ("JSON invalid identifer");
			return sb.ToString ();
		}
		public static string ParseString (ICharEnumeratorG e)
		{
			bool skipRead = false;
			char q = e.Current;
			if ('\'' != q && '\"' != q)
				return null;
			StringBuilder sb = new StringBuilder (); 
			while (skipRead || e.MoveNext ()) {
				skipRead = false;
				char ch = e.Current;
				if (ch == q) {
					e.MoveNext ();
					return sb.ToString ();	
				}
				switch (ch) {
				case '\\':
					if (!e.MoveNext ())
						throw new InvalidOperationException("JSON string is missing an end quote.");
					ch = (char)e.Current;
					switch (ch) {
					case '\'':
					case '\"':
					case '\\':
					case '/':
						sb.Append (ch);
						break;
					case't':
						sb.Append (@"\t");
						break;
					case 'f':
						sb.Append (@"\f");
						break;
					case 'n':
						sb.Append (@"\n");
						break;
					case 'r':
						sb.Append (@"\r");
						break;
					case 'b':
						sb.Append (@"\b");
						break;
					case 'u':
						if (!e.MoveNext ())
							throw new InvalidOperationException ("JSON string has an invalid unicode escape sequence.");
						int val = 0;
						ch = e.Current;
						for (int i = 0; i < 4; ++i) {
							val *= 16;
							if (ch >= 'a' && ch <= 'f')
								val += ((ch - 'a') + 10);
							else if (ch >= 'A' && ch <= 'F')
								val += ((ch - 'F') + 10);
							else if (ch >= '0' && ch <= '9')
								val += (ch - '0');
							else
								throw new InvalidOperationException ("JSON string has an invalid unicode escape sequence.");
							if (!e.MoveNext ())
								throw new InvalidOperationException ("JSON string has an unterminated unicode escape sequence.");
							ch = e.Current;
						}
						sb.Append (val);
						skipRead = true;
						if (e.Current == q) {
							e.MoveNext ();
							return sb.ToString ();	
						}
						break;
					default:
						throw new InvalidOperationException ("JSON string has an invalid escape character.");
					}
					break;
				default:
					sb.Append (ch);
					break;
				}

			}
			throw new InvalidOperationException("JSON string is missing an end quote.");
		}

		private static bool SkipWhitespace (ICharEnumeratorG e)
		{
			if (char.IsWhiteSpace (e.Current)) {
				while (e.MoveNext ()) {
					if (!char.IsWhiteSpace (e.Current))
						break;
				}
				return true;
			}
			return false;
		}
		#endif

		public static object Parse (TextReader @json)
		{
			using (TextReaderEnumerator e = new TextReaderEnumerator(@json)) {
				if (e.MoveNext ()) {
					return Parse (e);
				}
				throw new InvalidOperationException ("JSON value empty.");
			}
		}

		#region Get Methods
		public static object Get (object root, string field)
		{
			if (object.ReferenceEquals (null, field))
				throw new ArgumentNullException ("field");
			if (0 == field.Length) {
				return root;
			}
			#if NET20 || NET40
			if (root is IStringObjectDictionaryG)
				return ((IStringObjectDictionaryG)root) [field];
			#endif
			if (root is IDictionary) {
				return ((IDictionary)root) [field];
			}
			throw new InvalidOperationException ("Cannot index the specified JSON value. Operation failed while requesting field \"" + field + "\".");
		}

		public static object Get (object root, int index)
		{
			if (0 > index)
				throw new InvalidOperationException ("Illegal index " + index.ToString () + " into JSON object.");
			#if NET20 || NET40
			if (root is IListG)
				return ((IListG)root) [index];
			#endif
			if (root is IList)
				return ((IList)root) [index];
			throw new InvalidOperationException ("Cannot index the specified JSON value. Operation failed while requesting index " + index.ToString () + ".");
		}

		public static object Get (object root, object child)
		{
			if (child is int) {
				return Get (root, (int)child);
			}
			if (child is string) {
				return Get (root, (string)child);
			}
			throw new InvalidOperationException ("Cannot use this type of index with the specified JSON value. Operation failed while requesting child { " + child.ToString () + " }.");
		}

		public static object Get (object root, IEnumerable children)
		{
			if (object.ReferenceEquals (null, children))
				throw new ArgumentNullException ("children");
			object result = root;
			foreach (object child in children) {
				result = Get (result, child);
			}
			return result;
		}

		public static object Get (object root, params object[] children)
		{
			if (object.ReferenceEquals (null, children))
				throw new ArgumentNullException ("children");
			int l = children.Length;
			object result = root;
			for (int i = 0; i < l; ++i) {
				result = Get (result, children [i]);
			}
			return result;
		}
		#endregion Get Methods

		public static string ToString(object json) {
			StringBuilder result = new StringBuilder();
			WriteTo(result,json);
			return result.ToString();
		}
		public static string ToString(object json,string indent) {
			StringBuilder result = new StringBuilder();
			WriteTo(result,json,indent);
			return result.ToString();
		}
		public static void WriteTo(TextWriter writer,object json) {
			if(object.ReferenceEquals(null,json)) {
				writer.Write("null");
				return;
			}
			if(json is bool) {
				writer.Write (((bool)json) ? "true" : "false");
				return;
			}
			if(json is double) {
				writer.Write ((double)json);
				return;
			}
			if(json is string) {
				writer.Write ('\"');
				foreach (char ch in ((string)json)) {
					switch (ch) {
					case '\t':
						writer.Write("\\t");
						break;
					case '\n':
						writer.Write("\\n");
						break;
					case '\r':
						writer.Write("\\r");
						break;
					case '\f':
						writer.Write("\\f");
						break;
					case '\b':
						writer.Write("\\b");
						break;
					case ' ': // don't want space to get caught up in control processing.
						writer.Write(' ');
						break;
					case '\"':
						writer.Write("\\\"");
						break;
					default:
						if (char.IsSurrogate (ch) || char.IsControl (ch)) {
							writer.Write("\\u");
							writer.Write(((short)ch).ToString ("x4"));
							break;
						}
						writer.Write(ch);
						break;
					}
				}
				writer.Write('\"');
				return;
			}
			#if NET20 || NET40
			if(json is IListG) {
				writer.Write('[');
				bool first = true;
				foreach(object v in ((IListG)json)) {
					if (first)
						first = false;
					else
						writer.Write(',');
					WriteTo (writer, v);
				}
				writer.Write(']');
				return;
			}
			#endif
			if(json is IList) {
				writer.Write('[');
				bool first = true;
				foreach(object v in ((IList)json)) {
					if (first)
						first = false;
					else
						writer.Write(',');
					WriteTo (writer, v);
				}
				writer.Write(']');
				return;
			}
			#if NET20 || NET40
			if(json is IStringObjectDictionaryG) {
				writer.Write('{');
				bool first = true;
				foreach(StringObjectPairG sop in ((IStringObjectDictionaryG)json)) {
					if (first)
						first = false;
					else
						writer.Write(',');
					WriteTo (writer, sop.Key);
					writer.Write(':');
					WriteTo (writer, sop.Value);
				}
				writer.Write('}');
				return;
			}
			#endif
			if(json is IDictionary) {
				writer.Write('{');
				bool first = true;
				foreach(DictionaryEntry de in ((IDictionary)json)) {
					if (first)
						first = false;
					else
						writer.Write(',');

					WriteTo (writer, de.Key);
					writer.Write(':');
					WriteTo (writer, de.Value);
				}
				writer.Write('}');
				return;
			}
		}
		public static void WriteTo(TextWriter writer,object json,string indent) {
			WriteTo (writer, json, 0, indent);
		}
		private static void WriteTo(TextWriter writer,object json,int indentLevel,string indent) {
			if(null!=indent && indentLevel>0)
				for(int i = 0;i<indentLevel;++i)
					writer.Write(indent);
			if (indentLevel < 0)
				indentLevel = -indentLevel;
			if(object.ReferenceEquals(null,json)) {
				writer.Write("null");
				return;
			}
			if(json is bool) {
				writer.Write (((bool)json) ? "true" : "false");
				return;
			}
			if(json is double) {
				writer.Write ((double)json);
				return;
			}
			if(json is string) {
				writer.Write ('\"');
				foreach (char ch in ((string)json)) {
					switch (ch) {
					case '\t':
						writer.Write("\\t");
						break;
					case '\n':
						writer.Write("\\n");
						break;
					case '\r':
						writer.Write("\\r");
						break;
					case '\f':
						writer.Write("\\f");
						break;
					case '\b':
						writer.Write("\\b");
						break;
					case ' ': // don't want space to get caught up in control processing.
						writer.Write(' ');
						break;
					case '\"':
						writer.Write("\\\"");
						break;
					default:
						if (char.IsSurrogate (ch) || char.IsControl (ch)) {
							writer.Write("\\u");
							writer.Write(((short)ch).ToString ("x4"));
							break;
						}
						writer.Write(ch);
						break;
					}
				}
				writer.Write('\"');
				return;
			}
			int c = -1;
			#if NET20 || NET40
			if(json is IListG) {
				c=((IListG)json).Count;
				writer.Write('[');
				if(0==c){
					writer.Write (']');
					return;
				} else {
					writer.WriteLine();
				}
				bool first = true;
				foreach(object v in ((IListG)json)) {
					if (first)
						first = false;
					else
						writer.WriteLine(',');
					WriteTo (writer, v,indentLevel+1,indent);
				}
				writer.WriteLine();
				for(int i = 0;i<indentLevel;++i) {
					writer.Write(indent);	
				}
				writer.Write(']');
				return;
			}
			#endif
			if(json is IList) {
				c=((IList)json).Count;
				writer.Write('[');
				if(0==c){
					writer.Write (']');
					return;
				} else {
					writer.WriteLine();
				}
				bool first = true;
				foreach(object v in ((IList)json)) {
					if (first)
						first = false;
					else
						writer.WriteLine(',');
					WriteTo (writer, v,(indentLevel+1),indent);
				}
				writer.WriteLine();
				for(int i = 0;i<indentLevel;++i) {
					writer.Write(indent);	
				}
				writer.Write(']');
				return;
			}
			#if NET20 || NET40
			if(json is IStringObjectDictionaryG) {
				c=((IStringObjectDictionaryG)json).Count;
				writer.Write('{');
				if(0==c){
					writer.Write ('}');
					return;
				} else {
					writer.WriteLine();
				}
				bool first = true;
				foreach(StringObjectPairG sop in ((IStringObjectDictionaryG)json)) {
					if (first)
						first = false;
					else
						writer.WriteLine(',');
					WriteTo (writer, sop.Key,indentLevel+1,indent);
					writer.Write(": ");
					WriteTo (writer, sop.Value,-(indentLevel+1),indent );
				}
				writer.WriteLine();
				for(int i = 0;i<indentLevel;++i) {
					writer.Write(indent);	
				}
				writer.Write('}');
				return;
			}
			#endif
			if(json is IDictionary) {
				c=((IDictionary)json).Count;
				writer.Write('{');
				if(0==c){
					writer.Write ('}');
					return;
				} else {
					writer.WriteLine();
				}
				bool first = true;
				foreach(DictionaryEntry de in ((IDictionary)json)) {
					if (first)
						first = false;
					else
						writer.WriteLine(",");
					WriteTo (writer, de.Key,indentLevel+1,indent);
					writer.Write(": ");
					WriteTo (writer, de.Value,-(indentLevel+1),indent);
				}
				for(int i = 0;i<indentLevel;++i) {
					writer.Write(indent);	
				}
				writer.Write('}');
				return;
			}
		}
		public static void WriteTo(StringBuilder builder,object json,string indent) {
			WriteTo (builder, json, 0, indent);
		}
		private static void WriteTo(StringBuilder builder,object json,int indentLevel,string indent) {
			if(null!=indent && indentLevel>0)
				for(int i = 0;i<indentLevel;++i)
					builder.Append(indent);
			if (indentLevel < 0)
				indentLevel = -indentLevel;
			if(object.ReferenceEquals(null,json)) {
				builder.Append("null");
				return;
			}
			if(json is bool) {
				builder.Append(((bool)json) ? "true" : "false");
				return;
			}
			if(json is double) {
				builder.Append((double)json);
				return;
			}
			if(json is string) {
				builder.Append('\"');
				foreach (char ch in ((string)json)) {
					switch (ch) {
					case '\t':
						builder.Append("\\t");
						break;
					case '\n':
						builder.Append("\\n");
						break;
					case '\r':
						builder.Append("\\r");
						break;
					case '\f':
						builder.Append("\\f");
						break;
					case '\b':
						builder.Append("\\b");
						break;
					case ' ': // don't want space to get caught up in control processing.
						builder.Append(' ');
						break;
					case '\"':
						builder.Append("\\\"");
						break;
					default:
						if (char.IsSurrogate (ch) || char.IsControl (ch)) {
							builder.Append("\\u");
							builder.Append(((short)ch).ToString ("x4"));
							break;
						}
						builder.Append(ch);
						break;
					}
				}
				builder.Append('\"');
				return;
			}
			int c = -1;
			#if NET20 || NET40
			if(json is IListG) {
				c=((IListG)json).Count;
				builder.Append('[');
				if(0==c){
					builder.Append(']');
					return;
				} else {
					builder.AppendLine();
				}
				bool first = true;
				foreach(object v in ((IListG)json)) {
					if (first)
						first = false;
					else
						builder.AppendLine(",");
					WriteTo (builder, v,indentLevel+1,indent);
				}
				builder.AppendLine();
				for(int i = 0;i<indentLevel;++i) {
					builder.Append(indent);	
				}
				builder.Append(']');
				return;
			}
			#endif
			if(json is IList) {
				c=((IList)json).Count;
				builder.Append('[');
				if(0==c){
					builder.Append(']');
					return;
				} else {
					builder.AppendLine();
				}
				bool first = true;
				foreach(object v in ((IList)json)) {
					if (first)
						first = false;
					else
						builder.AppendLine(",");
					WriteTo (builder, v,(indentLevel+1),indent);
				}
				builder.AppendLine();
				for(int i = 0;i<indentLevel;++i) {
					builder.Append(indent);	
				}
				builder.Append(']');
				return;
			}
			#if NET20 || NET40
			if(json is IStringObjectDictionaryG) {
				c=((IStringObjectDictionaryG)json).Count;
				builder.Append('{');
				if(0==c){
					builder.Append('}');
					return;
				} else {
					builder.AppendLine();
				}
				bool first = true;
				foreach(StringObjectPairG sop in ((IStringObjectDictionaryG)json)) {
					if (first)
						first = false;
					else
						builder.AppendLine(",");
					WriteTo (builder, sop.Key,indentLevel+1,indent);
					builder.Append(": ");
					WriteTo (builder, sop.Value,-(indentLevel+1),indent );
				}
				builder.AppendLine();
				for(int i = 0;i<indentLevel;++i) {
					builder.Append(indent);	
				}
				builder.Append('}');
				return;
			}
			#endif
			if(json is IDictionary) {
				c=((IDictionary)json).Count;
				builder.Append('{');
				if(0==c){
					builder.Append('}');
					return;
				} else {
					builder.AppendLine();
				}
				bool first = true;
				foreach(DictionaryEntry de in ((IDictionary)json)) {
					if (first)
						first = false;
					else
						builder.AppendLine(",");
					WriteTo (builder, de.Key,indentLevel+1,indent);
					builder.Append(": ");
					WriteTo (builder, de.Value,-(indentLevel+1),indent);
				}
				for(int i = 0;i<indentLevel;++i) {
					builder.Append(indent);	
				}
				builder.Append('}');
				return;
			}
		}
		public static void WriteTo(StringBuilder builder,object json) {
			if(object.ReferenceEquals(null,json)) {
				builder.Append("null");
				return;
			}
			if(json is bool) {
				builder.Append (((bool)json) ? "true" : "false");
				return;
			}
			if(json is double) {
				builder.Append ((double)json);
				return;
			}
			if(json is string) {
				builder.Append ('\"');
				foreach (char ch in ((string)json)) {
					switch (ch) {
					case '\t':
						builder.Append ("\\t");
						break;
					case '\n':
						builder.Append ("\\n");
						break;
					case '\r':
						builder.Append ("\\r");
						break;
					case '\f':
						builder.Append ("\\f");
						break;
					case '\b':
						builder.Append ("\\b");
						break;
					case ' ': // don't want space to get caught up in control processing.
						builder.Append (' ');
						break;
					case '\"':
						builder.Append ("\\\"");
						break;
					default:
						if (char.IsSurrogate (ch) || char.IsControl (ch)) {
							builder.Append ("\\u");
							builder.Append (((short)ch).ToString ("x4"));
							break;
						}
						builder.Append (ch);
						break;
					}
				}
				builder.Append ('\"');
				return;
			}
			#if NET20 || NET40
			if(json is IListG) {
				builder.Append ('[');
				bool first = true;
				foreach(object v in ((IListG)json)) {
					if (first)
						first = false;
					else 
						builder.Append (',');
					WriteTo (builder, v);
				}
				builder.Append (']');
				return;
			}
			#endif
			if(json is IList) {
				builder.Append ('[');
				bool first = true;
				foreach(object v in ((IList)json)) {
					if (first)
						first = false;
					else
						builder.Append (',');
					WriteTo (builder, v);
				}
				builder.Append (']');
				return;
			}
			#if NET20 || NET40
			if(json is IStringObjectDictionaryG) {
				builder.Append ('{');
				bool first = true;
				foreach(StringObjectPairG sop in ((IStringObjectDictionaryG)json)) {
					if (first)
						first = false;
					else
						builder.Append (',');
					WriteTo (builder, sop.Key);
					builder.Append (':');
					WriteTo (builder, sop.Value);
				}
				builder.Append ('}');
				return;
			}
			#endif
			if(json is IDictionary) {
				builder.Append ('{');
				bool first = true;
				foreach(DictionaryEntry de in ((IDictionary)json)) {
					if (first)
						first = false;
					else
						builder.Append (',');

					WriteTo (builder, de.Key);
					builder.Append (':');
					WriteTo (builder, de.Value);
				}
				builder.Append ('}');
				return;
			}
		}
		public static ArrayList ParseArray (IEnumerator e)
		{
			if ('[' != (char)e.Current)
				return null;
			if (!e.MoveNext ())
				throw new InvalidOperationException ("JSON array unterminated.");
			ArrayList result = new ArrayList ();
			SkipWhitespace (e);
			char ch = (char)e.Current;
			if (',' == ch)
				throw new InvalidOperationException ("JSON array contains empty element");
			if (']' == ch) {
				e.MoveNext ();
				return result;
			}
			while (true) {
				result.Add (Parse (e));
				SkipWhitespace (e);
				ch = (char)e.Current;
				switch (ch) {
				case ']':

					e.MoveNext ();
					return result;
				case ',':
					if (!e.MoveNext ())
						throw new InvalidOperationException ("JSON array unterminated.");
					break;
				default:
					throw new InvalidOperationException ("Unexpected character in JSON array.");
				}
				SkipWhitespace (e);
			}
		}

		public static Hashtable ParseObject (IEnumerator e)
		{
			if ('{' != (char)e.Current)
				return null;
			if (!e.MoveNext ())
				throw new InvalidOperationException ("JSON object unterminated.");
			Hashtable result = new Hashtable ();
			SkipWhitespace (e);
			char ch = (char)e.Current;
			if (',' == ch)
				throw new InvalidOperationException ("JSON object contains empty element");
			if ('}' == ch) {
				e.MoveNext ();
				return result;
			}
			while (true) {
				string key = ParseString (e);
				if (null == key) 
					key = ParseIdentifier (e);
				if (null == key) 
					throw new InvalidOperationException ("Could not parse key in JSON object");
				SkipWhitespace (e);
				ch = (char)e.Current;
				if (':' != ch || !e.MoveNext ())
					throw new InvalidOperationException ("Could not parse value in JSON object");
				SkipWhitespace (e);
				object value = Parse (e);
				SkipWhitespace (e);
				result.Add (key, value);
				ch = (char)e.Current;
				switch (ch) {
				case '}':
					e.MoveNext ();
					return result;
				case ',':
					if (!e.MoveNext ())
						throw new InvalidOperationException ("JSON object unterminated.");
					break;
				default:
					throw new InvalidOperationException ("Unexpected character in JSON array.");
				}
				SkipWhitespace (e);
			}
		}

		private static void ParseCombineDigits (IEnumerator e, int part, ref double accumulator)
		{
			// combines accumulating numberic values and parsing into one operation.
			// part indicates which form we're processing
			// 0 indicates a series of digits will be interpreted as a positive integral value - ex: "123" will result in a double precision value of 123
			// 1 indicates a series of digits will be interpreted as a fractional value - ex: "123" will result in a double precision value of .123
			// in both of the above cases, the parsed value will be added to the accumlator value

			// 2 indicates a series of digits will be interpreted as a positive exponent value. the accumulator contains the input value and the next string indicates the expononent such that 1.2E3 would mean 1.2 was passed as the accumulated value, and here we're about to parse '3'. The accumulator will have the exponent multiplicand (1000) applied here. 
			// 3 indicates a series of digits will be interpreted as a positive exponent value. the accumulator contains the input value and the next string indicates the expononent such that 1.2E-3 would mean 1.2 was passed as the accumulated value, and here we're about to parse '3'. The accumulator will have the exponent divisor (1000) applied here. 

			char ch = (char)e.Current;
			if (!(ch >= '0' && ch <= '9'))
				return;
			double result = 0.0d;
			double count;
			long exp;
			switch (part) {
			case 1: // frac part
				count = 1d;
				while (ch >= '0' && ch <= '9') {
					result *= 10;
					count *= .1;
					result += (int)(ch - '0');

					if (!e.MoveNext ())
						break;
					ch = (char)e.Current;
				}
				accumulator += (result * count);
				return;
			case 2: // E(+) part
				if ('0' == ch)
					throw new InvalidOperationException ("Invalid JSON Number."); // exp can't have a leading zero.
				exp = 0;
				while (ch >= '0' && ch <= '9') {
					exp *= 10;
					exp += (int)(ch - '0');
					if (!e.MoveNext ())
						break;
					ch = (char)e.Current;
				}
				accumulator *= Math.Pow (10, exp);
				return;
			case 3: // E- part
				if ('0' == ch)
					throw new InvalidOperationException ("Invalid JSON Number."); // exp can't have a leading zero.
				exp = 0;
				while (ch >= '0' && ch <= '9') {
					exp *= 10;
					exp += (int)(ch - '0');
					if (!e.MoveNext ())
						break;
					ch = (char)e.Current;
				}
				accumulator /= Math.Pow (10, exp);
				return;

			default: // 0 - standard integer part.
				while (ch >= '0' && ch <= '9') {
					result *= 10;
					result += (int)(ch - '0');
					if (!e.MoveNext ())
						break;
					ch = (char)e.Current;
				}
				accumulator += result;
				return; 
			}
		}

		public static double ParseNumber (IEnumerator e)
		{

			bool neg = false;
			char ch = (char)e.Current;
			if ('-' == ch) { // handle leading '-'
				if (!e.MoveNext ())
					throw new InvalidOperationException ("Invalid JSON Number"); // '-' at the end of the input
				neg = true;
				ch = (char)e.Current;

			}
			if ('0' == ch) {
				if (!e.MoveNext ()) {
					if (neg)
						throw new InvalidOperationException ("Invalid JSON Number"); // -0{EOS} invalid
					return 0.0d;
				}
				ch = (char)e.Current;
				if (ch != '.') {
					if (neg || (ch >= '0' && ch <= '9')) // -0 or 0{digits} invalid;
						throw new InvalidOperationException ("Invalid JSON Number");
					return 0.0d;
				}
			}
			double result = 0.0d;
			ch = (char)e.Current;

			if (ch >= '0' && ch <= '9') {
				ParseCombineDigits (e, 0, ref result); // shouldn't return false.
				ch = (char)e.Current;
			}
			if (ch == '.') {
				if (!e.MoveNext ())
					throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}.{EOS}

				ch = (char)e.Current;
				if (ch < '0' || ch > '9') // invalid {result}.[^0-9]
					throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}.{EOS}
				ParseCombineDigits (e, 1, ref result);
				ch = (char)e.Current;
			}
			if (ch == 'e' || ch == 'E') {
				if (!e.MoveNext ())
					throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}[Ee]{EOS}
				ch = (char)e.Current;
				int s = 2;
				if (ch == '+') {
					if (!e.MoveNext ())
						throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}[Ee]+{EOS}
					ch = (char)e.Current;
				} else if (ch == '-') {
					s = 3;
					if (!e.MoveNext ())
						throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}[Ee]-{EOS}
					ch = (char)e.Current;
				}
				if (ch < '0' || ch > '9') // invalid {result}[^0-9]
					throw new InvalidOperationException ("Invalid JSON Number"); // invalid {result}[^0-9]
				ParseCombineDigits (e, s, ref result);
			}
			if (neg)
				result = -result;
			return result;
		}

		public static object Parse (IEnumerable @json)
		{
			IEnumerator e = @json.GetEnumerator ();
			try {
				if (e.MoveNext ()) {
					return Parse (e);
				}
				return null;
			} finally {
				IDisposable d = e as IDisposable;
				if (!object.ReferenceEquals (null, d))
					d.Dispose ();
				d = null;
				e = null;
			}
		}

		public static object Parse (IEnumerator e)
		{
			SkipWhitespace (e);
			char ch = (char)e.Current;
			switch (ch) {
			case 't':
				if (!e.MoveNext () || 'r' != (char)e.Current || !e.MoveNext () || 'u' != (char)e.Current || !e.MoveNext () || 'e' != (char)e.Current || (e.MoveNext () && char.IsLetterOrDigit ((char)e.Current)))
					goto default;
				return true;
			case 'f':
				if (!e.MoveNext () || 'a' != (char)e.Current || !e.MoveNext () || 'l' != (char)e.Current || !e.MoveNext () || 's' != (char)e.Current || !e.MoveNext () || 'e' != (char)e.Current || (e.MoveNext () && char.IsLetterOrDigit ((char)e.Current)))
					goto default;
				return false;
			case 'n':
				if (!e.MoveNext () || 'u' != (char)e.Current || !e.MoveNext () || 'l' != (char)e.Current || !e.MoveNext () || 'l' != (char)e.Current || (e.MoveNext () && char.IsLetterOrDigit ((char)e.Current)))
					goto default;
				return null;				
			case '[':
				ArrayList al = ParseArray (e);
				return al;
			case '{':
				Hashtable ht = ParseObject (e);
				return ht;
			case '\"':
				goto case '\'';
			case '\'':
				return ParseString (e);

			case '-':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				return ParseNumber (e);

			default:
				throw new InvalidOperationException ("JSON value invalid.");
			}

		}
		public static string ParseIdentifier (IEnumerator e)
		{
			char ch = (char)e.Current;
			if ('_'!=ch && !char.IsLetter (ch))
				return null;
			StringBuilder sb = new StringBuilder (); 
			sb.Append (ch);
			while (e.MoveNext ()) {
				ch = (char)e.Current;
				if (!('_' == ch || '-' == ch || char.IsLetterOrDigit (ch)))
					break;
				sb.Append (ch);
			}
			if (':' != ch)
				throw new InvalidOperationException ("JSON invalid identifer");
			return sb.ToString ();
		}
		public static string ParseString (IEnumerator e)
		{
			bool skipRead = false;
			char q = (char)e.Current;
			if ('\'' != q && '\"' != q)
				return null;
			StringBuilder sb = new StringBuilder (); 
			while (skipRead || e.MoveNext ()) {
				skipRead = false;
				char c = (char)e.Current;
				if (c == q) {
					e.MoveNext ();
					return sb.ToString ();	
				}
				switch (c) {
				case '\\':
					if (!e.MoveNext ())
						throw new InvalidOperationException ("JSON string is missing an end quote.");
					c = (char)e.Current;
					switch (c) {
					case '\'':
					case '\"':
					case '\\':
					case '/':
						sb.Append (c);
						break;
					case't':
						sb.Append (@"\t");
						break;
					case 'f':
						sb.Append (@"\f");
						break;
					case 'n':
						sb.Append (@"\n");
						break;
					case 'r':
						sb.Append (@"\r");
						break;
					case 'b':
						sb.Append (@"\b");
						break;
					case 'u':
						if (!e.MoveNext ())
							throw new InvalidOperationException ("JSON string has an invalid unicode escape sequence.");
						int val = 0;
						c = (char)e.Current;
						for (int i = 0; i < 4; ++i) {
							val *= 16;
							if (c >= 'a' && c <= 'f')
								val += ((c - 'a') + 10);
							else if (c >= 'A' && c <= 'F')
								val += ((c - 'F') + 10);
							else if (c >= '0' && c <= '9')
								val += (c - '0');
							else
								throw new InvalidOperationException ("JSON string has an invalid unicode escape sequence.");
							if (!e.MoveNext ())
								throw new InvalidOperationException ("JSON string has an unterminated unicode escape sequence.");
							c = (char)e.Current;
						}
						sb.Append ((char)val);
						skipRead = true;
						if ((char)e.Current == q) {
							e.MoveNext ();
							return sb.ToString ();	
						}
						break;
					default:
						throw new InvalidOperationException ("JSON string has an invalid escape character.");
					}
					break;
				default:
					sb.Append (c);
					break;
				}
			}
			throw new InvalidOperationException ("JSON string is missing an end quote.");
		}

		private static bool SkipWhitespace (IEnumerator e)
		{
			if (char.IsWhiteSpace ((char)e.Current)) {
				while (e.MoveNext ()) {
					if (!char.IsWhiteSpace ((char)e.Current))
						break;
				}
				return true;
			}
			return false;
		}
	}
}

