using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UserRectDemo;

namespace WeaveImagePatternExtractor
{
    public partial class MainForm : Form
    {
        ExtractForm extractForm;

        Bitmap imgIn; // source image
        Bitmap imgPattern; // extracted pattern image
        Bitmap imgEditor; // editor image (with zoomed pixels)
        Bitmap imgPreview; // preview of the repetive pattern

        Rectangle selection;

        UserRect selRect;

        public MainForm()
        {
            InitializeComponent();
            extractForm = new ExtractForm();
            extractForm.ExtractPatternCompleted = ExtractPatternCompleted;

            selRect = new UserRect(new Rectangle(0, 0, 21, 21));
            selRect.allowDeformingDuringMovement = true;
            selRect.sizeChanged = sizeChanged;
            selRect.xSnapSize = 11;
            selRect.ySnapSize = 11;
            selRect.SetPictureBox(this.picEditor);
        }

        private void sizeChanged(Rectangle rect)
        {
            textBox1.Text = rect.ToString();
        }

        private void ExtractPatternCompleted(Bitmap imgPattern)
        {
            this.imgPattern = imgPattern;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
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
            imgPattern = new Bitmap(xParts, yParts);
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

                    if (nr > threshold)
                        imgPattern.SetPixel(x, y, color1);
                    else
                        imgPattern.SetPixel(x, y, color2);
                }
            }
        }

        private void PrintZoomedPatternImage()
        {
            int pixelSize = Int32.Parse(txtEditorPixelSize.Text);
            int pixelSpacing = Int32.Parse(txtEditorPixelSpacing.Text);
            imgEditor = new Bitmap(imgPattern.Width * (pixelSize + pixelSpacing)+1, imgPattern.Height * (pixelSize + pixelSpacing)+1);
            Graphics graphics = Graphics.FromImage(imgEditor);
            for (int y = 0; y < imgPattern.Height; y++)
            {
                for (int x = 0; x < imgPattern.Width; x++)
                {
                    int x2 = x * (pixelSize + pixelSpacing);
                    int y2 = y * (pixelSize + pixelSpacing);
                    graphics.FillRectangle(new SolidBrush(imgPattern.GetPixel(x, y)), x2, y2, pixelSize, pixelSize);
                }
            }
            //picEditor.Image = null;
            picEditor.Image = imgEditor;
        }

        private void PrintPreviewPatternImage()
        {
            int pixelSize = Int32.Parse(txtPreviewPixelSize.Text);
            int pixelSpacing = Int32.Parse(txtPreviewPixelSpacing.Text);
            int pixelTotalSize = (pixelSize + pixelSpacing);
            imgPreview = new Bitmap(picPreview.ClientRectangle.Width, picPreview.ClientRectangle.Height);
            Graphics graphics = Graphics.FromImage(imgPreview);
            int xCopies = imgPreview.Width / imgPattern.Width;
            int yCopies = imgPreview.Height / imgPattern.Height;
            for (int xc=0;xc<xCopies;xc++)
            {
                for (int yc=0;yc<yCopies;yc++)
                {
                    for (int y = 0; y < imgPattern.Height; y++)
                    {
                        for (int x = 0; x < imgPattern.Width; x++)
                        {
                            int x2 = x * pixelTotalSize + xc*imgPattern.Width*pixelTotalSize;
                            int y2 = y * pixelTotalSize + yc*imgPattern.Height*pixelTotalSize;
                            graphics.FillRectangle(new SolidBrush(imgPattern.GetPixel(x, y)), x2, y2, pixelSize, pixelSize);
                        }
                    }
                }
            }
            //picPreview.Image = null;
            picPreview.Image = imgPreview;
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            ExtractPatternFromSource();
            PrintZoomedPatternImage();
            PrintPreviewPatternImage();
        }

        private void lblColor1_Click(object sender, EventArgs e)
        {
            colorDialog.Color = lblColor1.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                lblColor1.BackColor = colorDialog.Color;
        }

        private void lblColor2_Click(object sender, EventArgs e)
        {
            colorDialog.Color = lblColor2.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                lblColor2.BackColor = colorDialog.Color;
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
        
        private Bitmap CropImageSize(Bitmap img, int newWidth, int newHeight)
        {
            Bitmap newImg = new Bitmap(newWidth, newHeight);
            //if (img.Width < newWidth) newWidth = img.Width;
            //if (img.Height < newHeight) newHeight = img.Height;

            for (int x=0;x<newWidth;x++)
            {
                for (int y=0;y<newHeight;y++)
                {
                    if (x < img.Width && y < img.Height)
                        newImg.SetPixel(x, y, img.GetPixel(x, y));
                    else
                        newImg.SetPixel(x, y, lblEditColor2.BackColor);
                }
            }
            return newImg;
        }

        private void btnUpdateEditor_Click(object sender, EventArgs e)
        {
            int height = Int32.Parse(txtEditorImageHeight.Text);
            int width = Int32.Parse(txtEditorImageWidth.Text);
            if (height != imgPattern.Height || width != imgPattern.Width) {
                imgPattern = CropImageSize(imgPattern, width, height);
                PrintPreviewPatternImage();
            }
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
            bool print = false;
            Color pc = Color.Black;
            if (e.Button == MouseButtons.Left)
            {
                print = true;
                pc = lblEditColor1.BackColor;
            }
            else if (e.Button == MouseButtons.Right)
            {
                print = true;
                pc = lblEditColor2.BackColor;
            }
            if (print)
            {
                int x = editorXpixel, y = editorYpixel;
                int pixelSize = Int32.Parse(txtEditorPixelSize.Text);
                int pixelSpacing = Int32.Parse(txtEditorPixelSpacing.Text);
                imgPattern.SetPixel(x, y, pc);
                Graphics graphics = Graphics.FromImage(imgEditor);
                int x2 = x * (pixelSize + pixelSpacing);
                int y2 = y * (pixelSize + pixelSpacing);
                graphics.FillRectangle(new SolidBrush(pc), x2, y2, pixelSize, pixelSize);
                picEditor.Invalidate(new Rectangle(x2, y2, pixelSize, pixelSize));
            }

        }

        private void picEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                PrintPreviewPatternImage();
        }

        private void btnOpenPattern_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (ofd.ShowDialog() != DialogResult.OK) return;

            imgPattern = new Bitmap(ofd.FileName);
            txtEditorImageHeight.Text = imgPattern.Height.ToString();
            txtEditorImageWidth.Text = imgPattern.Width.ToString();
            patternFileName = ofd.FileName;
            PrintZoomedPatternImage();
            PrintPreviewPatternImage();
        }

        string patternFileName = "";

        private bool SelectNewFileName(ref string filepath)
        {
            filepath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() != DialogResult.OK) return false;
            filepath = sfd.FileName;
            return true;
        }

        private void btnSavePattern_Click(object sender, EventArgs e)
        {
            if (patternFileName == "")
            {
                if (SelectNewFileName(ref patternFileName) == false) return;
            }
            imgPattern.Save(patternFileName);
        }

        private void btnSavePatternAs_Click(object sender, EventArgs e)
        {
            string newName = "";
            if (SelectNewFileName(ref newName) == false) return;
            patternFileName = newName;
            imgPattern.Save(patternFileName);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tsmiOpenExtractForm_Click(object sender, EventArgs e)
        {
            extractForm.Visible = true;
        }
    }
}
