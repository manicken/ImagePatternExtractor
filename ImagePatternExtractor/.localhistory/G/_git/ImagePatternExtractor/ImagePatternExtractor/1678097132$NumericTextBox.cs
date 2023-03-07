using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WeaveImagePatternExtractor
{
    public class NumericTextBox : GenericNumericTextBox<double> { }

    public class GenericNumericTextBox<T> : TextBox
    {
        private readonly char _decimalSeparator =
            CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

        public GenericNumericTextBox()
        {
            TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != _decimalSeparator)
            {
                e.Handled = true;
            }

            if (e.KeyChar == _decimalSeparator && Text.IndexOf(_decimalSeparator) > -1)
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);

        }

        [Browsable(true)]
        public int Integer { get => int.TryParse(Text, out var value) ? value : DefaultIntValue; set => Text = value.ToString(); }
        [Browsable(true)]
        public decimal Decimal { get => decimal.TryParse(Text, out var value) ? value : DefaultDecimalValue; set => Text = value.ToString(); }
        [Browsable(true)]
        public double Double { get => double.TryParse(Text, out var value) ? value : DefaultDoubleValue; set => Text = value.ToString(); }
        [Browsable(true)]
        public int DefaultIntValue { get; set; } = 0;
        [Browsable(true)]
        public double DefaultDoubleValue { get; set; } = 0.0f;
        [Browsable(true)]
        public decimal DefaultDecimalValue { get; set; } = Decimal.Zero;

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
                    if (c == _decimalSeparator)
                    {
                        count++;
                        if (count > 1)
                        {
                            return;
                        }
                    }
                }

                foreach (var character in input)
                {

                    if (!char.IsControl(character) && !char.IsDigit(character) && character != _decimalSeparator)
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
