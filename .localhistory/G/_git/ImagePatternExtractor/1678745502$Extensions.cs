using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Xml;
using System.Runtime.InteropServices;

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
            int sizeMin = size * -1;
            int sizeMax = size;

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
                        for (int i = sizeMin; i <= sizeMax; i++)
                        {
                            for (int j = sizeMin; j <= sizeMax; j++)
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
        /// <summary>
        /// Sets a pixel of a grayscale image i.e. Format8bppIndexed
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color">grayscale color</param>
        public static void SetPixel(this Bitmap bitmap, int x, int y, byte color)
        {
            if (bitmap.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException("Bitmap format must be 8bpp grayscale");
            }
            // Lock the bitmap data
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(x, y, 1, 1), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            try
            {
                // Copy the bitmap data to a byte array
                byte[] pixels = new byte[1];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, 1);
                // Set the pixel value
                pixels[0] = color;
                // Copy the modified byte array back to the bitmap data
                Marshal.Copy(pixels, 0, bitmapData.Scan0, 1);
            }
            finally
            {
                // Unlock the bitmap data
                bitmap.UnlockBits(bitmapData);
            }
        }

        public static byte GetPixel(this Bitmap bitmap, int x, int y)
        {
            byte color = 0x00;
            if (bitmap.PixelFormat != PixelFormat.Format8bppIndexed)
            {
                throw new ArgumentException("Bitmap format must be 8bpp grayscale");
            }
            // Lock the bitmap data
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(x, y, 1, 1), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            try
            {
                // Copy the bitmap data to a byte array
                byte[] pixels = new byte[1];
                Marshal.Copy(bitmapData.Scan0, pixels, 0, 1);
                // Set the pixel value
                color = pixels[0];
            }
            finally
            {
                // Unlock the bitmap data
                bitmap.UnlockBits(bitmapData);
            }
            return color;
        }

        public static Bitmap ConvertToBinaryFormat8bppIndexed(this Bitmap bitmap)
        {
            Bitmap bmBin = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format8bppIndexed);
            BitmapData bmdBin = bmBin.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bmBin.PixelFormat);
            BitmapData bmdSrc = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            try
            {
                byte[] bmdBinRaw = new byte[bmdBin.Height * bmdBin.Stride];
                byte[] bmdSrcRaw = new byte[bmdSrc.Height * bmdSrc.Stride];
                Marshal.Copy(bmdSrc.Scan0, bmdSrcRaw, 0, bmdSrcRaw.Length);

                for (int si = 0, di = 0; si < bmdSrcRaw.Length; si += 4, di++)
                {
                    int average = ((int)bmdSrcRaw[si+1] + (int)bmdSrcRaw[si + 2] + (int)bmdSrcRaw[si + 3]) / 3;
                    bmdBinRaw[di] = (byte)average;
                }
                Marshal.Copy(bmdBinRaw, 0, bmdBin.Scan0, bmdBinRaw.Length);
            }
            finally
            {
                bmBin.UnlockBits(bmdBin);
                bitmap.UnlockBits(bmdSrc);
            }
            return bmBin;
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
