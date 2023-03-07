using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public static class Char_Ext
{
    /// <summary>
    /// short for character == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
    /// </summary>
    /// <param name="thisChar"></param>
    /// <returns></returns>
    public static bool IsDecimalSeperator(this System.Char thisChar)
    {
        return thisChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
    }
}
public static class KeyPressEventArgs_Ext
{
    /// <summary>
    /// Cancels the keypress event
    /// </summary>
    /// <param name="e"></param>
    public static void Cancel(this KeyPressEventArgs e)
    {
        e.Handled = true;
    }
}


namespace WeaveImagePatternExtractor
{
    

    public class IntegerValueTextBox : NumericTextBox<int> {
        public delegate void ValueChangedHandler(int value);
        public event ValueChangedHandler OnValueChanged;
        [Browsable(true)]
        public int DefaultValue { get; set; }
        public int Value { get => int.TryParse(Text, out var value) ? value : DefaultValue; set => Text = value.ToString(); }
        protected override void OnTextChanged(EventArgs e)
        {
            if (Value < DefaultValue || Text.Length == 0) Value = DefaultValue;
            if (OnValueChanged != null) OnValueChanged(Value);
            base.OnTextChanged(e);
        }
    }
    public class DoubleValueTextBox : NumericTextBox<double> {
        public delegate void ValueChangedHandler(double value);
        public event ValueChangedHandler OnValueChanged;
        [Browsable(true)]
        public double DefaultValue { get; set; }
        public double Value { get => double.TryParse(Text, out var value) ? value : DefaultValue; set => Text = value.ToString(); }
        protected override void OnTextChanged(EventArgs e)
        {
            if (Value < DefaultValue || Text.Length == 0) Value = DefaultValue;
            if (OnValueChanged != null) OnValueChanged(Value);
            base.OnTextChanged(e);
        }
    }
    public class DecimalValueTextBox : NumericTextBox<decimal> {
        public delegate void ValueChangedHandler(decimal value);
        public event ValueChangedHandler OnValueChanged;
        [Browsable(true)]
        public decimal DefaultValue { get; set; }
        public decimal Value { get => decimal.TryParse(Text, out var value) ? value : DefaultValue; set => Text = value.ToString(); }
        protected override void OnTextChanged(EventArgs e)
        {
            if (Value < DefaultValue || Text.Length == 0) Value = DefaultValue;
            if (OnValueChanged != null) OnValueChanged(Value);
            base.OnTextChanged(e);
        }
    }

    public class NumericTextBox<T> : TextBox
    {
        private readonly char _decimalSeparator =
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

        public NumericTextBox()
        {
            TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar.IsDecimalSeperator() && typeof(T) != typeof(int)))
            {
                e.Cancel();
            }
            if (typeof(T) != typeof(int))
            {
                // make sure that only one decimal-seperator can be entered
                if (e.KeyChar.IsDecimalSeperator() && Text.IndexOf(_decimalSeparator) > -1)
                {
                    e.Cancel();
                }
            }

            base.OnKeyPress(e);

        }


        public bool HasValue() => !string.IsNullOrWhiteSpace(Text);

        int WM_PASTE = 0x0302;
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_PASTE)
            {
                var clipboardData = Clipboard.GetDataObject();
                var input = (string)clipboardData?.GetData(typeof(string));
                int count = 0;

                foreach (var c in input)
                {
                    if (c.IsDecimalSeperator())
                    {
                        count++;
                        if (count > 1)
                        {
                            return;
                        }
                    }
                }

                foreach (var c in input)
                {

                    if (!char.IsControl(c) && !char.IsDigit(c) && !(c.IsDecimalSeperator() && typeof(T) != typeof(int)))
                    {
                        message.Result = (IntPtr)0;
                        return;
                    }

                }
            }

            base.WndProc(ref message);

        }
    }
}
