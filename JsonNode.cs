using System;
using System.Text;
using System.IO;
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

	using JU = JsonUtility;
	public enum JsonNodeType {
		Null=		0x00,
		Boolean=	0x01,
		Number=		0x02,
		String=		0x03,
		Array=		0x10,
		Object=		0x20,
	}
	public sealed class JsonNode 
	#if NET40
		: System.Dynamic.DynamicObject
	#endif 
	{
		#if NET40
		public override bool TryGetMember (System.Dynamic.GetMemberBinder binder, out object result)
		{
			if (base.TryGetMember (binder, out result))
				return true;
			if(_value is IStringObjectDictionaryG) {
				IStringObjectDictionaryG d = (IStringObjectDictionaryG)_value;
				if(d.TryGetValue (binder.Name, out result)) {
					result = new JsonNode (result);
					return true;
				}
				return false;
			}
			if(_value is IDictionary) {
				IDictionary d = (IDictionary)_value;
				if (d.Contains (binder.Name)) {
					result = new JsonNode(d [binder.Name]);
					return true;
				}
			}
			return false;

		}
		#endif
		object _value;
		public JsonNode(object value) {
			_value = value;
		}
		public JsonNodeType NodeType {
			get { 
				if (null == _value)
					return JsonNodeType.Null;
				if (_value is bool)
					return JsonNodeType.Boolean;
				if (_value is double)
					return JsonNodeType.Number;
				if (_value is string)
					return JsonNodeType.String;
				#if NET20 || NET40
				if (_value is IListG)
					return JsonNodeType.Array;
				#endif
				if (_value is IList)
					return JsonNodeType.Array;
				#if NET20 || NET40
				if (_value is IStringObjectDictionaryG)
					return JsonNodeType.Object;
				#endif
				if (_value is IDictionary)
					return JsonNodeType.Object;
				throw new InvalidDataException ("The value is not a supported JSON type.");
			}
		}
		public JsonNode this[int index] {
			get {
				return new JsonNode(JU.Get (_value, index));
			}
		}
		public JsonNode this[params object[] paths] {
			get { return new JsonNode (JU.Get(_value, paths)); }
		}

		public JsonNode this[string field] {
			get {
				return new JsonNode(JU.Get (_value, field));
			}
		}
		public object Value {
			get { return _value; }
			set { _value = value;}
		}

		public override string ToString ()
		{
			return JU.ToString (_value);
		}
		public string ToString (string indent)
		{
			return JU.ToString (_value,indent);
		}
		public void WriteTo(TextWriter writer) {
			JU.WriteTo (writer, _value);
		}
		public void WriteTo(TextWriter writer,string indent) {
			JU.WriteTo (writer, _value,indent);
		}
		public void WriteTo(StringBuilder builder) {
			JU.WriteTo (builder, _value);
		}
		public void WriteTo(StringBuilder builder,string indent) {
			JU.WriteTo (builder, _value,indent);
		}
		public static implicit operator bool(JsonNode left) {
			if (left._value is bool)
				return (bool)left._value;
			throw new InvalidCastException ("JSON object is not boolean.");
		}
		public static implicit operator string(JsonNode left) {
			if (left._value is string)
				return (string)left._value;
			throw new InvalidCastException ("JSON object is not a string.");
		}
		public static implicit operator double(JsonNode left) {
			if (left._value is double)
				return (double)left._value;
			throw new InvalidCastException ("JSON object is not a number.");
		}

		#if NET20 || NET40
		public static implicit operator StringObjectDictionaryG(JsonNode left) {
			if (left._value is StringObjectDictionaryG)
				return (StringObjectDictionaryG)left._value;
			throw new InvalidCastException ("JSON object is not a JObject.");
		}
		public static implicit operator ListG(JsonNode left) {
			if (left._value is ListG)
				return (ListG)left._value;
			throw new InvalidCastException ("JSON object is not a JArray.");
		}
		#endif 
		public static implicit operator Hashtable(JsonNode left) {
			if (left._value is Hashtable)
				return (Hashtable)left._value;
			throw new InvalidCastException ("JSON object is not a JObject.");
		}
		public static implicit operator ArrayList(JsonNode left) {
			if (left._value is ArrayList)
				return (ArrayList)left._value;
			throw new InvalidCastException ("JSON object is not a JArray.");
		}
		public static explicit operator object[](JsonNode left) {
			#if NET20 || NET40
			if (left._value is ListG)
				return ((ListG)left._value).ToArray ();
			#endif
			if (left._value is ArrayList)
				return ((ArrayList)left._value).ToArray ();

			throw new InvalidCastException ("JSON object is not a JArray.");
		}
		public static JsonNode Parse(TextReader reader) {return new JsonNode (JU.Parse (reader));}
		#if NET20 || NET40
		public static JsonNode Parse(ICharEnumerableG @string) {return new JsonNode (JU.Parse (@string));}
		#endif
		public static JsonNode Parse(IEnumerable @string) {return new JsonNode (JU.Parse (@string));}


	}
}

