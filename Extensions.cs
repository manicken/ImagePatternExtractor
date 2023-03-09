using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WeaveImagePatternExtractor
{
    public static class BitmapExt
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
