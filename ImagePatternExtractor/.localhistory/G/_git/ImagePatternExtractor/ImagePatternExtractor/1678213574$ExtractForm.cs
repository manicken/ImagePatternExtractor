using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WeaveImagePatternExtractor
{
    public partial class ExtractForm : Form
    {
        public Action<Bitmap> ExtractPatternCompleted;
        private Bitmap imgSrc;
        private Bitmap imgPattern;
        private ColorDialog cd;
        private int xParts = 0, yParts = 0;

        public ExtractForm()
        {
            InitializeComponent();
            cd = new ColorDialog();
            xParts = txtXparts.Value;
            yParts = txtYparts.Value;
            txtXparts.ValueChanged = delegate (int val) { xParts = val; };
            txtYparts.ValueChanged = delegate (int val) { yParts = val; };
        }


        private void ExtractForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false;
                e.Cancel = true;
                return;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (ofd.ShowDialog() != DialogResult.OK) return;

            imgSrc = new Bitmap(ofd.FileName);
            picBox.Image = imgSrc;
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            ExtractPatternFromSource();
            if (ExtractPatternCompleted != null)
                ExtractPatternCompleted(imgPattern);
        }

        private void ExtractPatternFromSource()
        {
            int xOffset = txtXoffset.Value;
            int yOffset = txtYoffset.Value;
            double xMult = (double)imgSrc.Width / (double)xParts;
            double yMult = (double)imgSrc.Height / (double)yParts;
            int rth = txtRthreshold.Value;
            int gth = txtGthreshold.Value;
            int bth = txtBthreshold.Value;
            int threshold = rth * 256 * 256 + gth * 256 + bth;
            imgPattern = new Bitmap(xParts, yParts);
            Color color1 = lblColor1.BackColor;
            Color color2 = lblColor2.BackColor;

            for (int y = 0; y < yParts; y++)
            {
                for (int x = 0; x < xParts; x++)
                {
                    int xPos = (int)(x * xMult) + xOffset;
                    int yPos = (int)(y * yMult) + yOffset;
                    Color c = imgSrc.GetPixel(xPos, yPos);

                    int nr = c.R * 256 * 256 + c.G * 256 + c.B;

                    if (nr > threshold)
                        imgPattern.SetPixel(x, y, color1);
                    else
                        imgPattern.SetPixel(x, y, color2);
                }
            }
        }

        private void ExtractPatternFromSourceByMeanValue()
        {
            
            imgPattern = new Bitmap(xParts, yParts);
            
            for (int y = 0; y < yParts; y++)
            {
                for (int x = 0; x < xParts; x++)
                {

                }
            }
        }
        private Color GetMean(int x, int y)
        {
            int R = 0, G = 0, B = 0;
            double xMult = (double)imgSrc.Width / (double)xParts;
            double yMult = (double)imgSrc.Height / (double)yParts;
            double pixelsInPart = xMult * yMult;
            int xPos = (int)(x * xMult);
            int yPos = (int)(y * yMult);

            R = (int)(R / pixelsInPart); G = (int)(G / pixelsInPart); B = (int)(B / pixelsInPart);
            return Color.FromArgb(R, G, B);
        }

        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (picBox.Image == null) return;
            if (e.Button == MouseButtons.Left)
                GetColor(e.X, e.Y);
        }

        private void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (picBox.Image == null) return;
            if (e.Button == MouseButtons.Left)
                GetColor(e.X, e.Y);
        }

        private void GetColor(Int32 mouseX, Int32 mouseY)
        {
            Int32 realW = picBox.Image.Width;
            Int32 realH = picBox.Image.Height;
            Int32 currentW = picBox.ClientRectangle.Width;
            Int32 currentH = picBox.ClientRectangle.Height;
            Double zoomW = (currentW / (Double)realW);
            Double zoomH = (currentH / (Double)realH);
            Double zoomActual = Math.Min(zoomW, zoomH);
            Double padX = zoomActual == zoomW ? 0 : (currentW - (zoomActual * realW)) / 2;
            Double padY = zoomActual == zoomH ? 0 : (currentH - (zoomActual * realH)) / 2;

            Int32 realX = (Int32)((mouseX - padX) / zoomActual);
            Int32 realY = (Int32)((mouseY - padY) / zoomActual);
            //lblPosXval.Text = realX < 0 || realX > realW ? "-" : realX.ToString();
            //lblPosYVal.Text = realY < 0 || realY > realH ? "-" : realY.ToString();

            Bitmap bmp = new Bitmap(picBox.Image);
            Color colour = bmp.GetPixel(realX, realY);
            txtRthreshold.Value = colour.R;
            txtGthreshold.Value = colour.G;
            txtBthreshold.Value = colour.B;
            bmp.Dispose();
        }

        private void btnSwitchColors_Click(object sender, EventArgs e)
        {
            Color c = lblColor1.BackColor;
            lblColor1.BackColor = lblColor2.BackColor;
            lblColor2.BackColor = c;
        }

        private void lblColor1_Click(object sender, EventArgs e)
        {
            cd.Color = lblColor1.BackColor;
            if (cd.ShowDialog() != DialogResult.OK) return;
            lblColor1.BackColor = cd.Color;
        }

        private void lblColor2_Click(object sender, EventArgs e)
        {
            cd.Color = lblColor2.BackColor;
            if (cd.ShowDialog() != DialogResult.OK) return;
            lblColor2.BackColor = cd.Color;
        }

        private void DrawExtractGrid()
        {
            int xParts = txtXparts.Value;
            int yParts = txtYparts.Value;
            double xMult = (double)imgSrc.Width / (double)xParts;
            double yMult = (double)imgSrc.Height / (double)yParts;
            Bitmap imgSrcWithGrid = new Bitmap(imgSrc);
            Graphics g = Graphics.FromImage(imgSrcWithGrid);
            for (int x = 0; x < xParts; x++)
            {
                g.DrawLine(new Pen(Color.Red), (int)(x * xMult), 0, (int)(x * xMult), (imgSrcWithGrid.Height - 1));
            }
            for (int y = 0; y < yParts; y++)
            {
                g.DrawLine(new Pen(Color.Red), 0, (int)(y * yMult), (imgSrcWithGrid.Width - 1), (int)(y * yMult));
            }
            picBox.Image = imgSrcWithGrid;
            //picBox.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawExtractGrid();
        }

        private void txtXorYparts_TextChanged(object sender, EventArgs e)
        {
            DrawExtractGrid();
        }
    }
}
