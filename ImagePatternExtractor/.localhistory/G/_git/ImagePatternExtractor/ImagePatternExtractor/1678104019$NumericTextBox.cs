﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public static class Char_Ext
{
    public static bool IsDecimalSeperator(this System.Char thisChar)
    {
        return thisChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
    }
}
public static class KeyPressEventArgs_Ext
{
    public static void Cancel(this KeyPressEventArgs e)
    {
        e.Handled = true;
    }
}


namespace WeaveImagePatternExtractor
{
    public class IntegerValueTextBox : NumericTextBox<int> {
        [Browsable(true)]
        public int DefaultValue { get; set; }
        public int Value { get => int.TryParse(Text, out var value) ? value : DefaultValue; set => Text = value.ToString(); }
    }
    public class DoubleValueTextBox : NumericTextBox<double> {
        [Browsable(true)]
        public double DefaultValue { get; set; }
        public double Value { get => double.TryParse(Text, out var value) ? value : DefaultValue; set => Text = value.ToString(); }
    }
    public class DecimalValueTextBox : NumericTextBox<decimal> {
        [Browsable(true)]
        public decimal DefaultValue { get; set; }
        public decimal Value { get => decimal.TryParse(Text, out var value) ? value : DefaultValue; set => Text = value.ToString(); }
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
            
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) && !e.KeyChar.IsDecimalSeperator())
            {
                e.Handled = true;
            }
            if (typeof(T) != typeof(int))
            {
                // make sure that only one decimal-seperator can be entered
                if (e.KeyChar.IsDecimalSeperator() && Text.IndexOf(_decimalSeparator) > -1)
                {
                    e.Handled = true;
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

                    if (!char.IsControl(character) && !char.IsDigit(character) && (character != _decimalSeparator && typeof(T) == typeof(int)))
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
