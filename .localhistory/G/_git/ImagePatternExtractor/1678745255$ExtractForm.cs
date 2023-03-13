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
            cd = new ColorDialog();
            advImgEditCtrlForm = new AdvancedImageEditControlsForm();
            advImgEditCtrlForm.PreviewContrastChange = advImgEditCtrlForm_PreviewContrastChange;
            advImgEditCtrlForm.ApplyContrastChange = advImgEditCtrlForm_ApplyContrastChange;
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

        private void advImgEditCtrlForm_PreviewContrastChange(int rc, int gc, int bc)
        {
            picBox.Image = imgSrc.SetContrast(rc, gc, bc);
            //DrawExtractGrid();
        }

        private void advImgEditCtrlForm_ApplyContrastChange(int rc, int gc, int bc)
        {
            imgSrc = imgSrc.SetContrast(rc, gc, bc);
            picBox.Image = imgSrc;
            //DrawExtractGrid();
        }

        private void FirstTimeOpenFile()
        {
            btnReopen.Enabled = true;
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

        private void btnReopen_Click(object sender, EventArgs e)
        {
            imgSrc = new Bitmap(imgSrcOriginal);
            picBox.Image = imgSrc;
            //DrawExtractGrid();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            SaveMetaData();
            ExtractPatternFromSource();
            if (ExtractPatternCompleted != null)
                ExtractPatternCompleted(imgPattern);
            grpThresholds.Enabled = true;
        }

        private void ExtractPatternFromSource()
        {
            long globalMeanR = 0;
            long globalMeanG = 0;
            long globalMeanB = 0;
            imgPattern = new Bitmap(xParts, yParts);
            
            for (int y = 0; y < yParts; y++)
            {
                for (int x = 0; x < xParts; x++)
                {
                    Color cm = GetMean(x, y);
                    globalMeanR += cm.R;
                    globalMeanG += cm.G;
                    globalMeanB += cm.B;
                    imgPattern.SetPixel(x, y, cm);
                }
            }
            
            globalMeanR /= (xParts * yParts);
            globalMeanG /= (xParts * yParts);
            globalMeanB /= (xParts * yParts);
            txtRthreshold.Value = (int)globalMeanR;
            txtGthreshold.Value = (int)globalMeanG;
            txtBthreshold.Value = (int)globalMeanB;
            if (chkProcessStep2.Checked == false) return;
            for (int y = 0; y < yParts; y++)
            {
                for (int x = 0; x < xParts; x++)
                {
                    Color c = imgPattern.GetPixel(x, y);
                    if (c.R > globalMeanR && c.G > globalMeanG && c.B > globalMeanB)
                        imgPattern.SetPixel(x, y, lblColor1.BackColor);
                    else
                        imgPattern.SetPixel(x, y, lblColor2.BackColor);
                }
            }
            
        }

        private Color GetMean(int x, int y)
        {
            int R = 0, G = 0, B = 0;
            double xMult = (double)imgSrc.Width / (double)xParts;
            double yMult = (double)imgSrc.Height / (double)yParts;
            int pixelsInPart = (int)xMult * (int)yMult;
            int xPos = (int)(x * xMult);
            int yPos = (int)(y * yMult);
            for (int xp = 0; xp < (int)xMult; xp++)
            {
                for (int yp = 0; yp < (int)yMult; yp++)
                {
                    Color c = imgSrc.GetPixel(xp + xPos, yp + yPos);
                    
                    R += c.R;
                    G += c.G;
                    B += c.B;
                }
            }
            R = R / pixelsInPart; G = G / pixelsInPart; B = B / pixelsInPart;
            return Color.FromArgb(R, G, B);
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
            Bitmap imgSrcCopy = new Bitmap(imgSrc);

            if (chkFilterGrayScale.Checked)
            {
                double r = dvtxtGrayScaleRed.Value;
                double g = dvtxtGrayScaleGreen.Value;
                double b = dvtxtGrayScaleBlue.Value;
                AForge.Imaging.Filters.Grayscale grayscaleFilter = new AForge.Imaging.Filters.Grayscale(r, g, b);
                imgSrcCopy = grayscaleFilter.Apply(imgSrcCopy);
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
                
                //AForge.Imaging.Filters.Grayscale grayscaleFilter = new AForge.Imaging.Filters.Grayscale(0.2125, 0.7154, 0.0721);
                //imgSrcCopy = grayscaleFilter.Apply(imgSrcCopy);

                for (int x = 0; x < 20; x++)
                    for (int y = 0; y < 20; y++)
                        imgSrcCopy.SetPixel(x, y, 0xFF);
            }
            if (chkFilterAdaptiveSmoothing.Checked)
            {
                //Accord.Imaging.Filters.AdaptiveSmoothing adaptiveSmoothingFilter = new Accord.Imaging.Filters.AdaptiveSmoothing();
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
                AForge.Imaging.Filters.Erosion erosionFilter = new AForge.Imaging.Filters.Erosion(FilterPatterns.Cross_3x3);
                var count = ivtxtErosionCount.Value;
                for (var i = 0; i < count; i++)
                    erosionFilter.ApplyInPlace(imgSrcCopy);
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
            picBox.Image = OCR_Filtering();
            //DrawExtractGrid();
        }

        private void btnOpenAIECF_Click(object sender, EventArgs e)
        {
            advImgEditCtrlForm.Visible = true;
        }

        private void tsmiPicBoxSaveAs_Click(object sender, EventArgs e)
        {
            imgSrc.SaveImageCopy(srcImgPath + "_OCR.PNG", ImageFormat.Png);
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            imgSrc = OCR_Filtering();
            picBox.Image = imgSrc;
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
