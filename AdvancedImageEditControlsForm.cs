using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WeaveImagePatternExtractor
{
    public partial class AdvancedImageEditControlsForm : Form
    {
        private Action<int, int, int> _PreviewContrastChange;
        private Action<int, int, int> _ApplyContrastChange;

        public Action<int, int, int> PreviewContrastChange
        {
            set
            {
                _PreviewContrastChange = value;
                btnContrastPreview.Enabled = (value == null) ? false : true;
            }
        }

        public Action<int, int, int> ApplyContrastChange
        {
            set
            {
                _ApplyContrastChange = value;
                btnContrastApply.Enabled = (value == null) ? false : true;
            }
        }

        public ContrastAdjRGBValue ContrastRGBValues
        {
            get { return new ContrastAdjRGBValue(tbRedContrast.Value, tbGreenContrast.Value, tbBlueContrast.Value); }
        }
        public AdvancedImageEditControlsForm()
        {
            InitializeComponent();
            btnContrastApply.Enabled = false;
            btnContrastPreview.Enabled = false;
        }

        private void Local_ResetContrast()
        {
            tbRedContrast.Value = 0;
            tbGreenContrast.Value = 0;
            tbBlueContrast.Value = 0;
            txtRedContrastValue.Text = "0";
            txtGreenContrastValue.Text = "0";
            txtBlueContrastValue.Text = "0";
        }

        private void btnApplyContrast_Click(object sender, EventArgs e)
        {
            Local_ResetContrast();
            _ApplyContrastChange(tbRedContrast.Value, tbGreenContrast.Value, tbBlueContrast.Value);
        }

        private void btnResetContrast_Click(object sender, EventArgs e)
        {
            Local_ResetContrast();
            if (_PreviewContrastChange == null) return;
            _PreviewContrastChange(tbRedContrast.Value, tbGreenContrast.Value, tbBlueContrast.Value);         
        }

        private void tbRedContrast_Scroll(object sender, EventArgs e)
        {
            txtRedContrastValue.Text = tbRedContrast.Value.ToString();
        }

        private void tbGreenContrast_Scroll(object sender, EventArgs e)
        {
            txtGreenContrastValue.Text = tbGreenContrast.Value.ToString();
        }

        private void tbBlueContrast_Scroll(object sender, EventArgs e)
        {
            txtBlueContrastValue.Text = tbBlueContrast.Value.ToString();
        }

        private void btnContrastPreview_Click(object sender, EventArgs e)
        {
            _PreviewContrastChange(tbRedContrast.Value, tbGreenContrast.Value, tbBlueContrast.Value);
        }

        private void AdvancedImageEditControlsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false; e.Cancel = true;
            }
        }
    }
    public class ContrastAdjRGBValue
    {
        public int R = 0, G = 0, B = 0;
        public ContrastAdjRGBValue(int R, int G, int B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }
    }
}
