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
        ColorDialog cd;

        Bitmap imgPattern; // extracted pattern image
        Bitmap imgEditor; // editor image (with zoomed pixels)
        Bitmap imgPreview; // preview of the repetive pattern

        UserRect selRect;

        public MainForm()
        {
            InitializeComponent();
            cd = new ColorDialog();
            extractForm = new ExtractForm();
            extractForm.ExtractPatternCompleted = ExtractPatternCompleted;

            selRect = new UserRect(new Rectangle(0, 0, 21, 21), this.picEditor);
            //selRect.AllowDeformingDuringMovement = false;
            selRect.DrawResizeHandles = false;
            selRect.SizeChanged = selRect_SizeChanged;
            selRect.SnapSize = txtEditorPixelSize.Value + txtEditorPixelSpacing.Value;
            cmbSelectionMode.SelectedIndex = 2;
            CreateNewPattern();
        }

        private Bitmap OpenAndReadImage(string path)
        {
            Bitmap bm;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                bm = new Bitmap(stream);
            }
            return bm;
        }

        private void CreateNewPattern()
        {
            imgPattern = new Bitmap(txtEditorImageWidth.Value, txtEditorImageHeight.Value);
            for (int x = 0; x < imgPattern.Width; x++)
                for (int y = 0; y < imgPattern.Height; y++)
                    imgPattern.SetPixel(x, y, lblEditColor2.BackColor);
            PrintZoomedPatternImage();
            PrintPreviewPatternImage();
        }
        private int count = 0;
        private void selRect_SizeChanged(Rectangle rect)
        {
            count++;
            textBox1.Text = "Selection: " + rect.ToString() + " " + count.ToString();
        }

        private void ExtractPatternCompleted(Bitmap imgPattern)
        {
            this.imgPattern = imgPattern;
            txtEditorImageHeight.Value = imgPattern.Height;
            txtEditorImageWidth.Value = imgPattern.Width;
            PrintZoomedPatternImage();
            PrintPreviewPatternImage();
        }

        private void PrintZoomedPatternImage()
        {
            int pixelSize = txtEditorPixelSize.Value;
            int pixelSpacing = txtEditorPixelSpacing.Value;
            imgEditor = new Bitmap(imgPattern.Width * (pixelSize + pixelSpacing)+2, imgPattern.Height * (pixelSize + pixelSpacing)+1);
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
            picEditor.Image = imgEditor;
        }

        private void PrintPreviewPatternImage()
        {
            int pixelSize = txtPreviewPixelSize.Value;
            int pixelSpacing = txtPreviewPixelSpacing.Value;
            int pixelTotalSize = (pixelSize + pixelSpacing);
            imgPreview = new Bitmap(picPreview.Width, picPreview.Height);
            Graphics graphics = Graphics.FromImage(imgPreview);
            int xCopies = imgPreview.Width / (imgPattern.Width*pixelTotalSize);
            int yCopies = imgPreview.Height / (imgPattern.Height*pixelTotalSize);
            integerValueTextBox1.Value = xCopies;
            integerValueTextBox2.Value = yCopies;
            int imgPatternWidth = imgPattern.Width - 1;
            int imgPatternWidth2 = imgPatternWidth;
            for (int xc=0;xc<xCopies;xc++)
            {
                if (xc == (xCopies - 1)) imgPatternWidth = imgPattern.Width;

                for (int yc=0;yc<yCopies;yc++)
                {

                    for (int y = 0; y < imgPattern.Height; y++)
                    {
                        for (int x = 0; x < imgPatternWidth; x++)
                        {
                            int x2 = x * pixelTotalSize + xc* imgPatternWidth2 * pixelTotalSize;
                            int y2 = y * pixelTotalSize + yc*imgPattern.Height*pixelTotalSize;
                            graphics.FillRectangle(new SolidBrush(imgPattern.GetPixel(x, y)), x2, y2, pixelSize, pixelSize);
                        }
                    }
                }
            }
            picPreview.Image = imgPreview;
        }

        private Bitmap CropImageSize(Bitmap img, int newWidth, int newHeight)
        {
            Bitmap newImg = new Bitmap(newWidth, newHeight);

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
            int height = txtEditorImageHeight.Value;
            int width = txtEditorImageWidth.Value;
            if (height != imgPattern.Height || width != imgPattern.Width) {
                imgPattern = CropImageSize(imgPattern, width, height);
                PrintPreviewPatternImage();
            }
            selRect.SnapSize = txtEditorPixelSize.Value + txtEditorPixelSpacing.Value;
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
            int pixelSize = txtEditorPixelSize.Value;
            int pixelSpacing = txtEditorPixelSpacing.Value;
            int pixelTotalSize = (pixelSize + pixelSpacing);
            editorXpixel = e.X / pixelTotalSize;
            editorYpixel = e.Y / pixelTotalSize;

            txtX.Value = editorXpixel;
            txtY.Value = editorYpixel;
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
                int pixelSize = txtEditorPixelSize.Value;
                int pixelSpacing = txtEditorPixelSpacing.Value;
                if (x >= imgPattern.Width) return;
                if (y >= imgPattern.Height) return;
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

        string patternFileName = "";

        private bool SelectNewFileName(ref string filepath)
        {
            filepath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG File|*.png";
            if (sfd.ShowDialog() != DialogResult.OK) return false;
            filepath = sfd.FileName;
            return true;
        }

        private void tsmiOpenExtractForm_Click(object sender, EventArgs e)
        {
            extractForm.Visible = true;
            extractForm.Left = this.Left - extractForm.Width;
            extractForm.Top = this.Top;
            extractForm.Height = this.Height;
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            extractForm.Left = this.Left - extractForm.Width;
            extractForm.Top = this.Top;
        }

        private void tsmiOpenPatternFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pattern Files|*.png;*bmp";

            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\ExamplePatterns";
            if (ofd.ShowDialog() != DialogResult.OK) return;

            imgPattern = OpenAndReadImage(ofd.FileName);
            txtEditorImageHeight.Value = imgPattern.Height;
            txtEditorImageWidth.Value = imgPattern.Width;
            patternFileName = ofd.FileName;
            PrintZoomedPatternImage();
            PrintPreviewPatternImage();
        }

        private void tsmiSavePatternFile_Click(object sender, EventArgs e)
        {
            if (patternFileName == "")
            {
                if (SelectNewFileName(ref patternFileName) == false) return;
            }
            imgPattern.Save(patternFileName);
        }

        private void tsmiSavePatternFileAs_Click(object sender, EventArgs e)
        {
            string newName = "";
            if (SelectNewFileName(ref newName) == false) return;
            patternFileName = newName;
            imgPattern.Save(patternFileName);
        }

        private void tsmiNewPatternConfirm_Click(object sender, EventArgs e)
        {
            CreateNewPattern();
            patternFileName = "";
        }

        private void lblColor1_Click(object sender, EventArgs e)
        {
            cd.Color = lblEditColor1.BackColor;
            if (cd.ShowDialog() != DialogResult.OK) return;
            lblEditColor1.BackColor = cd.Color;
        }

        private void lblColor2_Click(object sender, EventArgs e)
        {
            cd.Color = lblEditColor2.BackColor;
            if (cd.ShowDialog() != DialogResult.OK) return;
            lblEditColor2.BackColor = cd.Color;
        }

        private void btnSwitchColors_Click(object sender, EventArgs e)
        {
            Color c = lblEditColor1.BackColor;
            lblEditColor1.BackColor = lblEditColor2.BackColor;
            lblEditColor2.BackColor = c;
        }

        private void txtPreviewPixelSize_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
