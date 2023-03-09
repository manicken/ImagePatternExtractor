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
using Grimoire; // JSON utility https://www.codeproject.com/Articles/1225851/JsonUtility-A-Fast-Lightweight-Csharp-JSON-Drop-in

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
        private int xParts = 0, yParts = 0;
        private string srcImgPath = "";

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

        

        private void FirstTimeOpenFile()
        {
            btnReopen.Enabled = true;
            grpContrastAdj.Enabled = true;
            grpParts.Enabled = true;
            btnExtract.Enabled = true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\ExampleImages";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            srcImgPath = ofd.FileName;
            imgSrcOriginal = BitmapExt.OpenAndReadImage(srcImgPath);
            imgSrc = new Bitmap(imgSrcOriginal);

            ReadXmlMetadata();
            //PrintMetadata(imgSrcOriginal);

            

            DrawExtractGrid();
            FirstTimeOpenFile();
        }

        private void ReadXmlMetadata()
        {
            if (imgSrcOriginal.PropertyIdList.Contains<int>(0x9286) == false) return;
            PropertyItem pi = imgSrcOriginal.GetPropertyItem(0x9286);

            string xmlStr = new String(System.Text.Encoding.ASCII.GetChars(pi.Value));
            XmlDocument xmlDoc = new XmlDocument();
            xmlStr = xmlStr.Substring(0, xmlStr.LastIndexOf(">") + 1);
            rtxt.AppendText(xmlStr);
            xmlDoc.LoadXml(xmlStr);
            XmlNode psn = xmlDoc.SelectSingleNode("patternSizes");
            txtXparts.Text = psn.Attributes["x"].Value;
            txtYparts.Text = psn.Attributes["y"].Value;
        }

        private void PrintMetadata(Bitmap bm)
        {
            rtxt.AppendText("Property count: " + bm.PropertyIdList.Length.ToString() + Environment.NewLine);
            PropertyItem[] pis = bm.PropertyItems;
            for (int i=0;i< pis.Length;i++)
            {
                rtxt.AppendText(Environment.NewLine + pis[i].Id.ToString() + " " + pis[i].Type.ToString() +">>>>"+ new String(System.Text.Encoding.ASCII.GetChars(pis[i].Value)) +"<<<<<<<"+ Environment.NewLine);
            }
        }

        private void btnReopen_Click(object sender, EventArgs e)
        {
            imgSrc = new Bitmap(imgSrcOriginal);
            DrawExtractGrid();
        }

        private void SaveMetadata()
        {
            using (Bitmap bm = new Bitmap(imgSrcOriginal))
            {
                // Create a new PropertyItem object
                PropertyItem propItem = (PropertyItem)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(PropertyItem));
                // Set the PropertyItem ID to a custom value indicating a comment
                //propItem.Id = 0x010D; // DocumentName
                //propItem.Id = 0x010E; // ImageDescription
                propItem.Id = 0x9286; // ExifUserComment
                // Set the PropertyItem type to indicate the data format (in this case, ASCII string)
                propItem.Type = 2; // ASCII string type

                propItem.Value = System.Text.Encoding.ASCII.GetBytes(GenerateMetadataString());

                bm.SetPropertyItem(propItem);
                //if (Path.GetExtension(srcImgPath).ToLower().StartsWith(".jpg"))
                //    bm.Save(srcImgPath, ImageFormat.Jpeg);
                //else //if (Path.GetExtension(srcImgPath).ToLower() == ".png")
                    bm.Save(srcImgPath, ImageFormat.Png);
            }
        }

        private string GenerateMetadataString()
        {
            

            return "<patternSizes x = \""+ txtXparts.Text+ "\" y = \""+ txtYparts.Text + "\" />";
            
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            SaveMetadata();
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

        private void txtXorYparts_TextChanged(object sender, EventArgs e)
        {
            DrawExtractGrid();
        }

        private void btnApplyContrast_Click(object sender, EventArgs e)
        {
            imgSrc = imgSrc.SetContrast(tbRedContrast.Value, tbGreenContrast.Value, tbBlueContrast.Value);
            tbRedContrast.Value = 0;
            tbGreenContrast.Value = 0;
            tbBlueContrast.Value = 0;
        }

        private void btnResetContrast_Click(object sender, EventArgs e)
        {
            tbRedContrast.Value = 0;
            tbGreenContrast.Value = 0;
            tbBlueContrast.Value = 0;
            picBox.Image = imgSrc.SetContrast(tbRedContrast.Value, tbGreenContrast.Value, tbBlueContrast.Value);
            txtRedContrastValue.Text = "0";
            txtGreenContrastValue.Text = "0";
            txtBlueContrastValue.Text = "0";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            txtMedianVal.Text = trackBar1.Value.ToString();

            
        }

        private Bitmap PreFiltering()
        {
            Bitmap imgSrcCopy = new Bitmap(imgSrc);

            if (checkBox1.Checked)
            {
                AForge.Imaging.Filters.Grayscale grayscaleFilter = new AForge.Imaging.Filters.Grayscale(0.2125, 0.7154, 0.0721);
                imgSrcCopy = grayscaleFilter.Apply(imgSrcCopy);
            }
            if (checkBox2.Checked)
            {
                AForge.Imaging.Filters.Threshold thresholdFilter = new AForge.Imaging.Filters.Threshold(trackBar1.Value);
                imgSrcCopy = thresholdFilter.Apply(imgSrcCopy);
            }
            if (checkBox3.Checked)
            {
                AForge.Imaging.Filters.Median medianFilter = new AForge.Imaging.Filters.Median(1);
                medianFilter.ApplyInPlace(imgSrcCopy);
            }
            if (checkBox5.Checked)
            {
                // expand black areas
                //short[,] se = new short[3, 3] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
                AForge.Imaging.Filters.Erosion erosionFilter = new AForge.Imaging.Filters.Erosion();
                erosionFilter.ApplyInPlace(imgSrcCopy);
                erosionFilter.ApplyInPlace(imgSrcCopy);
                erosionFilter.ApplyInPlace(imgSrcCopy);
            }
            if (checkBox4.Checked)
            {
                // expand white areas
                short[,] se = new short[3, 3] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };
                AForge.Imaging.Filters.Dilatation dilateFilter = new AForge.Imaging.Filters.Dilatation(se);
                dilateFilter.ApplyInPlace(imgSrcCopy);
                dilateFilter.ApplyInPlace(imgSrcCopy);
            }

            return imgSrcCopy;
            //ExtractPatternCompleted(imgSrcCopy);
            //picBox.Image = imgSrcCopy;
        }
    
        private void btnPreviewFilter_Click(object sender, EventArgs e)
        {
            picBox.Image = PreFiltering();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            imgSrc = PreFiltering();
            picBox.Image = imgSrc;
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            picBox.Image = imgSrc.SetContrast(tbRedContrast.Value, tbGreenContrast.Value, tbBlueContrast.Value);
            txtRedContrastValue.Text = tbRedContrast.Value.ToString();
            txtGreenContrastValue.Text = tbGreenContrast.Value.ToString();
            txtBlueContrastValue.Text = tbBlueContrast.Value.ToString();
        }
    }
}

/* good functions to have
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
}*/