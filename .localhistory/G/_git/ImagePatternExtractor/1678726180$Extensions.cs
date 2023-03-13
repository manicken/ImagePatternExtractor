using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Xml;

namespace WeaveImagePatternExtractor
{
    public static class RichtextBoxExt
    {
        public static void AppendLine(this RichTextBox thisRtxt, string text)
        {
            thisRtxt.AppendText(text + Environment.NewLine);
        }
    }

    public static class XmlExt
    {
        public static XmlDocument NewXmlDocument(string data)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try { xmlDoc.LoadXml(data); }
            catch { return null; }
            return xmlDoc;
        }
       
    }

    public static class BitmapExt
    {
        private const string METADATA_END_STR = "<METADATA_END>"; // used because sometimes microsoft add random stuff to the end of actual data
        public static Bitmap OpenAndReadImage(string path)
        {
            Bitmap bm;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                bm = new Bitmap(stream);
            }
            return bm;
        }

        public static void SaveImageCopy(this Bitmap thisImg, string path, ImageFormat format)
        {
            Bitmap bm = new Bitmap(thisImg);
            bm.Save(path, format);
        }

        public static void SaveMetadata(this Bitmap thisImg, string imgFilePath, string metadataValue)
        {
            // save using new copy so that the input file don't get locked
            using (Bitmap bm = new Bitmap(thisImg))
            {
                PropertyItem propItem = (PropertyItem)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(PropertyItem));
                propItem.Id = 0x9286; // ExifUserComment
                // Set the PropertyItem type to indicate the data format (in this case, ASCII string)
                propItem.Type = 2; // ASCII string type
                propItem.Value = System.Text.Encoding.ASCII.GetBytes(metadataValue + METADATA_END_STR);
                propItem.Len = metadataValue.Length + 1;
                bm.SetPropertyItem(propItem);
                bm.Save(imgFilePath, ImageFormat.Png);
            }
        }

        public static bool GetMetadata(this Bitmap thisImg, out string data)
        {
            if (thisImg.PropertyIdList.Contains<int>(0x9286) == false) { data = ""; return false; }
            PropertyItem propItem = thisImg.GetPropertyItem(0x9286);
            data = new String(System.Text.Encoding.ASCII.GetChars(propItem.Value));
            int indexOf = data.LastIndexOf(METADATA_END_STR);
            //if (indexOf == -1) { data = ""; return false; }
            if (indexOf == -1) indexOf = data.LastIndexOf("/>") + 3;
            data = data.Substring(0, indexOf);
            return true;
        }

        public static bool GetMetadata(this Bitmap thisImg, out string data, out string debug)
        {
            debug = "";
            if (thisImg.GetMetadata(out data) == false) return false;
            debug += "pi.Value.Length: " + data.Length.ToString() + Environment.NewLine;
            debug += "pi.Value: " + data + Environment.NewLine;
            return true;
        }

        public static string PrintMetadata(this Bitmap bm)
        {
            string data = "";
            data += "Property count: " + bm.PropertyIdList.Length.ToString() + Environment.NewLine;
            PropertyItem[] pis = bm.PropertyItems;
            for (int i = 0; i < pis.Length; i++)
            {
                data += pis[i].Id.ToString();
                data += " " + pis[i].Type.ToString();
                data += ">>>>>>>" + new String(System.Text.Encoding.ASCII.GetChars(pis[i].Value)) + "<<<<<<<";
                data += Environment.NewLine;
            }
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binaryImage"></param>
        /// <param name="minPixelCount"></param>
        /// <param name="size">setting this to 1 gives 3x3 scanning area, 2=5x5, 3=7x7, 4=9x9 and so on</param>
        /// <returns></returns>
        public static Bitmap RemoveIsolatedPixels(this Bitmap binaryImage, int minPixelCount, int size)
        {
            // Create new bitmap to store cleaned image
            Bitmap cleanedImage = new Bitmap(binaryImage);
            PixelFormat.Format8bppIndexed
            MessageBox.Show(binaryImage.PixelFormat.ToString() + " to " + cleanedImage.PixelFormat.ToString());

            // Loop through each pixel in the image
            for (int x = 0; x < binaryImage.Width; x++)
            {
                for (int y = 0; y < binaryImage.Height; y++)
                {
                    // Check if pixel is foreground
                    if (binaryImage.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                    {
                        int pixelCount = 0;

                        // Count number of foreground pixels in 3x3 neighborhood
                        for (int i = -size; i <= size; i++)
                        {
                            for (int j = -size; j <= size; j++)
                            {
                                int neighborX = x + i;
                                int neighborY = y + j;

                                if (neighborX >= 0 && neighborX < binaryImage.Width &&
                                    neighborY >= 0 && neighborY < binaryImage.Height &&
                                    binaryImage.GetPixel(neighborX, neighborY).ToArgb() == Color.Black.ToArgb())
                                {
                                    pixelCount++;
                                }
                            }
                        }

                        // If number of foreground pixels is less than minPixelCount, set pixel to background
                        if (pixelCount < minPixelCount)
                        {
                            cleanedImage.SetPixel(x, y, Color.White);
                        }
                    }
                }
            }

            return cleanedImage;
        }

    public static Bitmap RemoveIsolatedPixels(Bitmap grayscaleImage, int minPixelCount)
    {
        // Create new bitmap to store cleaned image
        Bitmap cleanedImage = new Bitmap(grayscaleImage.Width, grayscaleImage.Height, PixelFormat.Format8bppIndexed);

        // Set grayscale color palette for cleanedImage
        ColorPalette palette = cleanedImage.Palette;
        for (int i = 0; i < 256; i++)
        {
            palette.Entries[i] = Color.FromArgb(i, i, i);
        }
        cleanedImage.Palette = palette;

        // Lock both bitmaps to get direct access to their pixels
        BitmapData grayscaleData = grayscaleImage.LockBits(new Rectangle(0, 0, grayscaleImage.Width, grayscaleImage.Height), ImageLockMode.ReadOnly, grayscaleImage.PixelFormat);
        BitmapData cleanedData = cleanedImage.LockBits(new Rectangle(0, 0, cleanedImage.Width, cleanedImage.Height), ImageLockMode.WriteOnly, cleanedImage.PixelFormat);

        // Get pixel size in bytes for each bitmap
        int grayscalePixelSize = Bitmap.GetPixelFormatSize(grayscaleImage.PixelFormat) / 8;
        int cleanedPixelSize = Bitmap.GetPixelFormatSize(cleanedImage.PixelFormat) / 8;

        // Loop through each pixel in the image
        for (int y = 0; y < grayscaleData.Height; y++)
        {
            byte* grayscaleRow = (byte*)grayscaleData.Scan0 + (y * grayscaleData.Stride);
            byte* cleanedRow = (byte*)cleanedData.Scan0 + (y * cleanedData.Stride);

            for (int x = 0; x < grayscaleData.Width; x++)
            {
                byte grayscaleValue = grayscaleRow[x * grayscalePixelSize];
                byte cleanedValue = grayscaleValue;

                // Check if pixel is foreground
                if (grayscaleValue == 0)
                {
                    int pixelCount = 0;

                    // Count number of foreground pixels in 3x3 neighborhood
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int neighborX = x + i;
                            int neighborY = y + j;

                            if (neighborX >= 0 && neighborX < grayscaleData.Width &&
                                neighborY >= 0 && neighborY < grayscaleData.Height)
                            {
                                byte neighborValue = *(grayscaleRow + (neighborX * grayscalePixelSize) + (neighborY * grayscaleData.Stride));
                                if (neighborValue == 0)
                                {
                                    pixelCount++;
                                }
                            }
                        }
                    }

                    // If number of foreground pixels is less than minPixelCount, set pixel to background
                    if (pixelCount < minPixelCount)
                    {
                        cleanedValue = 255;
                    }
                }

                // Set cleaned pixel value
                *(cleanedRow + (x * cleanedPixelSize)) = cleanedValue;
            }
        }

        // Unlock both bitmaps
        grayscaleImage.UnlockBits(grayscaleData);
        cleanedImage.UnlockBits(cleanedData);

        return cleanedImage;
    }


    public static Bitmap SetContrast(this Bitmap thisBmp, int threshold)
        {
            var cBmp = new Bitmap(thisBmp);

            var contrast = Math.Pow((100.0 + threshold) / 100.0, 2);

            for (int y = 0; y < thisBmp.Height; y++)
            {
                for (int x = 0; x < thisBmp.Width; x++)
                {
                    var oldColor = thisBmp.GetPixel(x, y);
                    var red = ((((oldColor.R / 255.0) - 0.5) * contrast) + 0.5) * 255.0;
                    var green = ((((oldColor.G / 255.0) - 0.5) * contrast) + 0.5) * 255.0;
                    var blue = ((((oldColor.B / 255.0) - 0.5) * contrast) + 0.5) * 255.0;
                    if (red > 255)
                        red = 255;
                    if (red < 0)
                        red = 0;
                    if (green > 255)
                        green = 255;
                    if (green < 0)
                        green = 0;
                    if (blue > 255)
                        blue = 255;
                    if (blue < 0)
                        blue = 0;

                    var newColor = Color.FromArgb(oldColor.A, (int)red, (int)green, (int)blue);
                    cBmp.SetPixel(x, y, newColor);
                }
            }
            return cBmp;
        }
        public static Bitmap SetContrast(this Bitmap thisBmp, int redThreshold, int greenThreshold, int blueThreshold)
        {
            var cBmp = new Bitmap(thisBmp);

            var redContrast = Math.Pow((100.0 + redThreshold) / 100.0, 2);
            var greenContrast = Math.Pow((100.0 + greenThreshold) / 100.0, 2);
            var blueContrast = Math.Pow((100.0 + blueThreshold) / 100.0, 2);

            for (int y = 0; y < thisBmp.Height; y++)
            {
                for (int x = 0; x < thisBmp.Width; x++)
                {
                    var oldColor = thisBmp.GetPixel(x, y);
                    var red = ((((oldColor.R / 255.0) - 0.5) * redContrast) + 0.5) * 255.0;
                    var green = ((((oldColor.G / 255.0) - 0.5) * greenContrast) + 0.5) * 255.0;
                    var blue = ((((oldColor.B / 255.0) - 0.5) * blueContrast) + 0.5) * 255.0;
                    if (red > 255)
                        red = 255;
                    if (red < 0)
                        red = 0;
                    if (green > 255)
                        green = 255;
                    if (green < 0)
                        green = 0;
                    if (blue > 255)
                        blue = 255;
                    if (blue < 0)
                        blue = 0;

                    var newColor = Color.FromArgb(oldColor.A, (int)red, (int)green, (int)blue);
                    cBmp.SetPixel(x, y, newColor);
                }
            }
            return cBmp;
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
