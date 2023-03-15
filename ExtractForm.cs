using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using LightWeightJsonParser; // from https://github.com/progklb/lightweight-json-parser
using System.Drawing.Drawing2D;

//using AForge.Imaging.Filters;


namespace WeaveImagePatternExtractor
{
    
    public partial class ExtractForm : Form
    {
        public Action<Bitmap> ExtractPatternCompleted;
        private Bitmap imgSrcOriginal;
        private Bitmap imgSrc;        
        private Bitmap imgPattern;
        private ColorDialog cd;
        private AdvancedImageEditControlsForm advImgEditCtrlForm;
        private int xParts = 0, yParts = 0;
        private string srcImgPath = "";

        public ExtractForm()
        {
            InitializeComponent();
            init_perspective_correction_selection_rectangle();
            cd = new ColorDialog();
            advImgEditCtrlForm = new AdvancedImageEditControlsForm();
            xParts = txtXparts.Value;
            yParts = txtYparts.Value;
            txtXparts.ValueChanged = delegate (int val) { xParts = val; };
            txtYparts.ValueChanged = delegate (int val) { yParts = val; };
        }

        private void ExtractForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Visible = false; e.Cancel = true;
            }
        }

        private void FirstTimeOpenFile()
        {
            btnShowOriginal.Enabled = true;
            grpParts.Enabled = true;
            btnExtract.Enabled = true;
            btnOpenAIECF.Enabled = true;
            grpOCRFilter.Enabled = true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\ExampleImages";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            srcImgPath = ofd.FileName;
            imgSrcOriginal = BitmapExt.OpenAndReadImage(srcImgPath);
            imgSrc = new Bitmap(imgSrcOriginal);
            picBox.Image = imgSrc;
            ReadXmlMetadata();
            //rtxt.AppendLine(imgSrcOriginal.PrintMetadata());

            //DrawExtractGrid();
            FirstTimeOpenFile();
        }

        private void ReadXmlMetadata()
        {
            string data = "";
            if (imgSrcOriginal.GetMetadata(out data) == false) return;

            var xmlDoc = XmlExt.NewXmlDocument(data);
            if (xmlDoc == null) { rtxt.AppendLine("ERROR could not parse xml metadata:\r\n" + data); return; }
            var patternSizes = xmlDoc["patternSizes"];
            if (patternSizes == null) { rtxt.AppendLine("ERROR could not find patternSizes in metadata xmldoc"); return; }
            var xValAttr = patternSizes.Attributes["x"];
            var yValAttr = patternSizes.Attributes["y"];
            if (xValAttr == null || yValAttr == null) { rtxt.AppendLine("ERROR could not find attribute x and/or y"); return; }
            txtXparts.Text = xValAttr.Value;
            txtYparts.Text = yValAttr.Value;
        }

        private void SaveMetaData()
        {
            string data = "<patternSizes x = \"" + txtXparts.Text + "\" y = \"" + txtYparts.Text + "\" />";
            imgSrcOriginal.SaveMetadata(srcImgPath, data);
        }

        private void btnShowOriginal_Click(object sender, EventArgs e)
        {
            picBox.Image = imgSrcOriginal;
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            //if (haveOCRfilterRun == false)
            imgSrc = OCR_Filtering();
            SaveMetaData();
            //ExtractPatternFromSource();
            ExtractPatternFromGrayScaleSource();
            if (ExtractPatternCompleted != null)
                ExtractPatternCompleted(imgPattern);
        }

        private void TrimParts(Bitmap bm, int size)
        {
            Graphics g = Graphics.FromImage(bm);
            int xParts = txtXparts.Value;
            int yParts = txtYparts.Value;
            double xMult = (double)bm.Width / (double)xParts;
            double yMult = (double)bm.Height / (double)yParts;
            Pen pen = new Pen(Color.White, (int)size);
            for (var xi=0;xi<(xParts+1);xi++)
            {
                int x = (int)((double)xi * xMult);
                g.DrawLine(pen, x, 0, x, bm.Height);
            }
            for (var yi = 0; yi < (yParts+1); yi++)
            {
                int y = (int)((double)yi * yMult);
                g.DrawLine(pen, 0, y, bm.Width, y);
            }
        }

        private void ExtractPatternFromGrayScaleSource()
        {
            int threshold = tbExtractThreshold.Value;
            imgPattern = new Bitmap(xParts, yParts);
            bool debug = (chkProcessStep2.Checked == false);
            for (int y = 0; y < yParts; y++)
            {
                for (int x = 0; x < xParts; x++)
                {
                    int val = GetMeanFromGrayScale(x, y);
                    if (debug)
                        imgPattern.SetPixel(x, y, Color.FromArgb(val, val, val));
                    else
                    {
                        if (val > threshold) imgPattern.SetPixel(x, y, lblColor1.BackColor);
                        else imgPattern.SetPixel(x, y, lblColor2.BackColor);
                    }
                }
            }
        }

        private int GetMeanFromGrayScale(int x, int y)
        {
            int mv = 0;
            double xMult = (double)imgSrc.Width / (double)xParts;
            double yMult = (double)imgSrc.Height / (double)yParts;
            int pixelsInPart = (int)xMult * (int)yMult;
            int xPos = (int)(x * xMult);
            int yPos = (int)(y * yMult);
            
            for (int xp = 0; xp < (int)xMult; xp++)
            {
                for (int yp = 0; yp < (int)yMult; yp++)
                {
                    byte val = imgSrc.GetGrayPixel(xp + xPos, yp + yPos);
                    if (val > 0x0) mv++;
                }
            }
            return (int)(((double)mv / (double)pixelsInPart) * (double)255);
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

        private void DrawExtractGrid(Graphics g) // code generated mostly from ChatGPT
        {
            // Get the size of the image in the picture box
            int width = picBox.Image.Width;
            int height = picBox.Image.Height;

            // Get the size of the client area of the picture box
            int clientWidth = picBox.ClientSize.Width;
            int clientHeight = picBox.ClientSize.Height;

            // Calculate the scaling factor between image and client sizes
            double scaleX = (double)clientWidth / width;
            double scaleY = (double)clientHeight / height;
            double scale = Math.Min(scaleX, scaleY);

            // Calculate the size of the scaled image
            int scaledWidth = (int)(width * scale);
            int scaledHeight = (int)(height * scale);

            // Calculate the offset to center the scaled image
            int offsetX = (clientWidth - scaledWidth) / 2;
            int offsetY = (clientHeight - scaledHeight) / 2;

            int xParts = txtXparts.Value;
            int yParts = txtYparts.Value;
            double xSpacing = (width / (double)xParts * scale);
            double ySpacing = (height / (double)yParts * scale);

            // Create a pen to draw the grid lines
            Pen pen = new Pen(Color.FromArgb(64, Color.Red), 2);
            int y2 = offsetY + scaledHeight;
            int x2 = offsetX + scaledWidth;

            // Draw the vertical grid lines
            for (int i = 0; i < (xParts+1); i++)
            {
                int x = (int)(i * xSpacing) + offsetX;
                g.DrawLine(pen, x, offsetY, x, y2);
            }

            // Draw the horizontal grid lines
            for (int i = 0; i < (yParts+1); i++)
            {
                int y = (int)(i * ySpacing) + offsetY;
                g.DrawLine(pen, offsetX, y, x2, y);
            }

            // Dispose of the pen
            pen.Dispose();
        }

        private void picBox_Paint(object sender, PaintEventArgs e)
        {
            try { DrawExtractGrid(e.Graphics); }
            catch (Exception exp) { System.Console.WriteLine(exp.Message); }
        }

        private void txtXorYparts_TextChanged(object sender, EventArgs e)
        {
            picBox.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            txtMedianVal.Text = trackBar1.Value.ToString();

            
        }

        private Bitmap OCR_Filtering()
        {
            //perspective correction, keep here for ref
            //AForge.Imaging.Filters.QuadrilateralTransformation sqtf = new AForge.Imaging.Filters.QuadrilateralTransformation
            // http://www.aforgenet.com/framework/docs/html/7039a71d-a87d-47ef-7907-ad873118e374.htm for details

            Bitmap imgSrcCopy = new Bitmap(imgSrcOriginal);

            //for (int x = 0; x < 20; x++)
            //    for (int y = 0; y < 20; y++)
            //        imgSrcCopy.SetPixel(x, y, 0xFF);
            if (chkFilterContrast.Checked)
            {
                imgSrcCopy = imgSrcCopy.SetContrast(advImgEditCtrlForm.ContrastRGBValues);
                //int factor = 0;
                //AForge.Imaging.Filters.ContrastCorrection contrastCorrectionFilter = new AForge.Imaging.Filters.ContrastCorrection(factor);
                //contrastCorrectionFilter.ApplyInPlace(imgSrcCopy);
            }
            if (chkTrimParts.Checked)
            {
                TrimParts(imgSrcCopy, tvtxtTrimPartsSize.Value);
            }
            
            if (chkFilterGrayScale.Checked)
            {
                double r = dvtxtGrayScaleRed.Value;
                double g = dvtxtGrayScaleGreen.Value;
                double b = dvtxtGrayScaleBlue.Value;
                AForge.Imaging.Filters.Grayscale grayscaleFilter = new AForge.Imaging.Filters.Grayscale(r, g, b);
                imgSrcCopy = grayscaleFilter.Apply(imgSrcCopy);
                //imgSrcCopy = imgSrcCopy.ConvertToBinaryFormat8bppIndexed();
            }
            if (chkFilterThreshold.Checked)
            {
                AForge.Imaging.Filters.Threshold thresholdFilter = new AForge.Imaging.Filters.Threshold(trackBar1.Value);
                imgSrcCopy = thresholdFilter.Apply(imgSrcCopy);
            }
            if (chkFilterRemoveIsolatedPixels.Checked)
            {
                int pixelCount = ivtxtFilterRemoveIsolatedPixelsP1.Value;
                int areaSize = ivtxtFilterRemoveIsolatedPixelsP2.Value;
                imgSrcCopy = imgSrcCopy.RemoveIsolatedPixels(pixelCount, areaSize).ConvertToBinaryFormat8bppIndexed();
            }
            if (chkFilterAdaptiveSmoothing.Checked)
            {
                AForge.Imaging.Filters.AdaptiveSmoothing adaptiveSmoothingFilter = new AForge.Imaging.Filters.AdaptiveSmoothing(dvtxtFilterAdaptiveSmoothing.Value);
                adaptiveSmoothingFilter.ApplyInPlace(imgSrcCopy);
            }
            if (chkFilterMedian.Checked)
            {
                AForge.Imaging.Filters.Median medianFilter = new AForge.Imaging.Filters.Median(ivtxtFilterMedian.Value);
                medianFilter.ApplyInPlace(imgSrcCopy);
            }
            if (chkFilterPreDilatation.Checked)
            {
                // expand white areas
                AForge.Imaging.Filters.Dilatation dilateFilter = new AForge.Imaging.Filters.Dilatation(FilterPatterns.Cross_3x3);
                var count = ivtxtPreDilatationCount.Value;
                for (var i = 0; i < count; i++)
                    dilateFilter.ApplyInPlace(imgSrcCopy);
            }
            if (chkErosion.Checked)
            {
                // expand black areas
                AForge.Imaging.Filters.Erosion erosionFilter = new AForge.Imaging.Filters.Erosion(FilterPatterns.Square_3x3);

                BitmapData imgSrcCopyData = imgSrcCopy.LockBits(new Rectangle(0, 0, imgSrcCopy.Width, imgSrcCopy.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);

                var count = ivtxtErosionCount.Value;
                int xParts = txtXparts.Value;
                int yParts = txtYparts.Value;
                double xMult = (double)imgSrc.Width / (double)xParts;
                double yMult = (double)imgSrc.Height / (double)yParts;
                Rectangle rect = new Rectangle(0, 0, (int)xMult, (int)yMult);
                for (var xi = 0; xi < xParts; xi++)
                {
                    for (var yi = 0; yi < yParts; yi++)
                    {
                        rect.X = (int)((double)xi * xMult);
                        rect.Y = (int)((double)yi * yMult);

                        for (var i = 0; i < count; i++)
                            erosionFilter.ApplyInPlace(imgSrcCopyData, rect);
                    }
                    
                }

                imgSrcCopy.UnlockBits(imgSrcCopyData);
            }
            if (chkFilterDilatation.Checked)
            {
                // expand white areas
                AForge.Imaging.Filters.Dilatation dilateFilter = new AForge.Imaging.Filters.Dilatation(FilterPatterns.Cross_3x3);
                var count = ivtxtDilatationCount.Value;
                for (var i=0;i<count;i++)
                    dilateFilter.ApplyInPlace(imgSrcCopy);
            }
            return imgSrcCopy;
        }
    
        private void btnPreviewFilter_Click(object sender, EventArgs e)
        {
            imgSrc = OCR_Filtering();
            picBox.Image = imgSrc;
        }

        private void btnOpenAIECF_Click(object sender, EventArgs e)
        {
            advImgEditCtrlForm.Visible = true;
        }

        private void tsmiPicBoxSaveAs_Click(object sender, EventArgs e)
        {
            imgSrc.SaveImageCopy(srcImgPath + "_OCR.PNG", ImageFormat.Png);
        }

        private void tbExtractThreshold_Scroll(object sender, EventArgs e)
        {
            txtExtractThreshold.Text = tbExtractThreshold.Value.ToString();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            imgSrc = OCR_Filtering();
            picBox.Image = imgSrc;
        }


        // perspective correction selection rectangle
        private Point[] selectionCorners; // Array to store the four corners of the selection rectangle
        private bool isDragging; // Flag to indicate if the user is currently dragging a corner
        private int dragCornerIndex; // Index of the corner being dragged
        private Pen pcsrPen;
        private bool showSelRectangle = false;
        private void init_perspective_correction_selection_rectangle()
        {
            pcsrPen = new Pen(Color.Orange, 2);
            selectionCorners = new Point[] {
                new Point(100, 100),
                new Point(200, 100),
                new Point(200, 200),
                new Point(100, 200)
            };

            // Subscribe to mouse events for the PictureBox control
            picBox.MouseDown += PictureBox_MouseDown;
            picBox.MouseUp += PictureBox_MouseUp;
            picBox.MouseMove += PictureBox_MouseMove;
            picBox.Paint += pictureBox1_Paint;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (showSelRectangle)
            // Draw the selection rectangle on the PictureBox control
            e.Graphics.DrawPolygon(pcsrPen, selectionCorners);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the mouse is inside any of the corners of the selection rectangle
            for (int i = 0; i < selectionCorners.Length; i++)
            {
                Rectangle cornerRect = new Rectangle(selectionCorners[i].X - 5, selectionCorners[i].Y - 5, 10, 10);
                if (cornerRect.Contains(e.Location))
                {
                    isDragging = true;
                    dragCornerIndex = i;
                    break;
                }
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnSPCACR_Click(object sender, EventArgs e)
        {
            showSelRectangle = !showSelRectangle;
            picBox.Invalidate();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // Move the currently dragged corner of the selection rectangle
            if (isDragging)
            {
                selectionCorners[dragCornerIndex] = e.Location;
                picBox.Invalidate(); // Refresh the PictureBox to redraw the selection rectangle
            }
        }
    }
    public static class FilterPatterns
    {
        public static short[,] Cross_3x3 = new short[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
        public static short[,] Square_3x3 = new short[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
        public static short[,] Vertical_1x3 = new short[3, 3] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } };
        public static short[,] Horizontal_1x3 = new short[3, 3] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } };
    }
}
