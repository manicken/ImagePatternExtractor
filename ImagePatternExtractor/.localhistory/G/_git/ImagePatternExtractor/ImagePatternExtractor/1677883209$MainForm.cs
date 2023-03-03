using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class MainForm : Form
    {
        Bitmap imgIn; // source image
        Bitmap imgOut; // extracted pattern image
        Bitmap imgEditor; // editor image (with zoomed pixels)
        Bitmap imgPreview; // preview of the repetive pattern

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;

            imgIn = new Bitmap(ofd.FileName);
            

            picBox.Image = imgIn;
            
        }

        private void ExtractPatternFromSource()
        {
            int xOffset = Int32.Parse(txtXoffset.Text);
            int yOffset = Int32.Parse(txtYoffset.Text);
            int xParts = Int32.Parse(txtXparts.Text);
            int yParts = Int32.Parse(txtYparts.Text);
            double xMult = (double)imgIn.Width / Double.Parse(txtXparts.Text);
            double yMult = (double)imgIn.Height / Double.Parse(txtYparts.Text);
            int rth = Int32.Parse(txtRthreshold.Text);
            int gth = Int32.Parse(txtGthreshold.Text);
            int bth = Int32.Parse(txtBthreshold.Text);
            int threshold = rth * 256 * 256 + gth * 256 + bth;
            imgOut = new Bitmap(xParts, yParts);
            Color color1 = lblColor1.BackColor;
            Color color2 = lblColor2.BackColor;

            for (int y = 0; y < yParts; y++)
            {
                for (int x = 0; x < xParts; x++)
                {
                    int xPos = (int)(x * xMult) + xOffset;
                    int yPos = (int)(y * yMult) + yOffset;
                    Color c = imgIn.GetPixel(xPos, yPos);

                    int nr = c.R * 256 * 256 + c.G * 256 + c.B;

                    if (nr > threshold) imgOut.SetPixel(x, y, color1);
                    else imgOut.SetPixel(x, y, color2);
                }
            }
        }

        private void PrintZoomedPatternImage()
        {
            picEditor.Image = null;
            int pixelSize = Int32.Parse(txtEditorPixelSize.Text);
            int pixelSpacing = Int32.Parse(txtEditorPixelSpacing.Text);
            imgEditor = new Bitmap(imgOut.Width * (pixelSize + pixelSpacing), imgOut.Height * (pixelSize + pixelSpacing));
            Graphics graphics = Graphics.FromImage(imgEditor);
            for (int y = 0; y < imgOut.Height; y++)
            {
                for (int x = 0; x < imgOut.Width; x++)
                {
                    int x2 = x * (pixelSize + pixelSpacing);
                    int y2 = y * (pixelSize + pixelSpacing);
                    graphics.FillRectangle(new SolidBrush(imgOut.GetPixel(x, y)), x2, y2, pixelSize, pixelSize);
                }
            }
            picEditor.Image = imgEditor;
        }

        private void PrintPreviewPatternImage()
        {
            picPreview.Image = null;
            int pixelSize = Int32.Parse(txtPreviewPixelSize.Text);
            int pixelSpacing = Int32.Parse(txtPreviewPixelSpacing.Text);
            int pixelTotalSize = (pixelSize + pixelSpacing);
            imgPreview = new Bitmap(picPreview.ClientRectangle.Width, picPreview.ClientRectangle.Height);
            Graphics graphics = Graphics.FromImage(imgPreview);
            int xCopies = imgPreview.Width / imgOut.Width;
            int yCopies = imgPreview.Height / imgOut.Height;
            for (int xc=0;xc<xCopies;xc++)
            {
                for (int yc=0;yc<yCopies;yc++)
                {
                    for (int y = 0; y < imgOut.Height; y++)
                    {
                        for (int x = 0; x < imgOut.Width; x++)
                        {
                            int x2 = x * pixelTotalSize + xc*imgOut.Width*pixelTotalSize;
                            int y2 = y * pixelTotalSize + yc*imgOut.Height*pixelTotalSize;
                            graphics.FillRectangle(new SolidBrush(imgOut.GetPixel(x, y)), x2, y2, pixelSize, pixelSize);
                        }
                    }
                }
            }
            picPreview.Image = imgPreview;
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            ExtractPatternFromSource();
            PrintZoomedPatternImage();
            PrintPreviewPatternImage();
        }

        private void lblLargerThanThresholdColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = lblColor1.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                lblColor1.BackColor = colorDialog1.Color;
        }

        private void lblThresholdElseChar_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = lblColor2.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                lblColor2.BackColor = colorDialog1.Color;
        }

        private void btnSwitchColors_Click(object sender, EventArgs e)
        {
            Color c = lblColor1.BackColor;
            lblColor1.BackColor = lblColor2.BackColor;
            lblColor2.BackColor = c;

            lblColor1.ForeColor = lblColor2.BackColor;
            lblColor2.ForeColor = lblColor1.BackColor;

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
            txtRthreshold.Text = colour.R.ToString();
            txtGthreshold.Text = colour.G.ToString();
            txtBthreshold.Text = colour.B.ToString();
            bmp.Dispose();
        }

        private void btnUpdateEditor_Click(object sender, EventArgs e)
        {
            PrintZoomedPatternImage();
        }

        private void btnUpdatePreview_Click(object sender, EventArgs e)
        {
            PrintPreviewPatternImage();
        }

        int editorXpixel = 0;
        int editorYpixel = 0;

        private void picEditor_MouseMove(object sender, MouseEventArgs e)
        {
            int pixelSize = Int32.Parse(txtEditorPixelSize.Text);
            int pixelSpacing = Int32.Parse(txtEditorPixelSpacing.Text);
            int pixelTotalSize = (pixelSize + pixelSpacing);
            editorXpixel = e.X / pixelTotalSize;
            editorYpixel = e.Y / pixelTotalSize;

            txtX.Text = editorXpixel.ToString();
            txtY.Text = editorYpixel.ToString();
        }

        private void picEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                imgEditor.SetPixel(editorXpixel, editorYpixel, lblColor1.BackColor);
            }
            else if (e.Button == MouseButtons.Right)
            {
                imgEditor.SetPixel(editorXpixel, editorYpixel, lblColor2.BackColor);
            }
        }
    }
}
