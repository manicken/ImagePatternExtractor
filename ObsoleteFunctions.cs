using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WeaveImagePatternExtractor
{
    public static class BitMapExtObsolete
    {
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
        public static Bitmap SetContrast(this Bitmap thisBmp, ContrastAdjRGBValue cValues)
        {
            return thisBmp.SetContrast(cValues.R, cValues.G, cValues.B);
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
