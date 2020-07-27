using Catalyzer.Math;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Catalyzer.Graphics
{
    public class Captcha
    {
        public static byte[] Draw(string text, int width, int height, int left, int top, CaptchaSettings settings = null)
        {
            if (settings == null)
            {
                settings = new CaptchaSettings();
            }

            #region draw source bmp

            // init bmp and graphics
            Bitmap srcBmp = new Bitmap(width, height);
            System.Drawing.Graphics srcGraphics = System.Drawing.Graphics.FromImage(srcBmp);
            // draw bg
            srcGraphics.Clear(settings.BackColor);
            // set quality
            srcGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            srcGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            srcGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            // draw captcha text
            srcGraphics.DrawString(text, settings.Font, new SolidBrush(settings.ForeColor), new PointF(left, top));
            srcGraphics.Flush();

            // twist
            Bitmap tgtBmp = new Bitmap(width, height);
            System.Drawing.Graphics tgtGraphics = System.Drawing.Graphics.FromImage(tgtBmp);
            // draw bg
            tgtGraphics.Clear(settings.BackColor);
            // twist by sine
            var periosOffset = Randomness.RandomDouble(System.Math.PI * 2);
            for (int x = 0; x < width; x++)
            {
                var dx = x;

                for (int y = 0; y < height; y++)
                {
                    var color = srcBmp.GetPixel(x, y);

                    var dy = (int)(System.Math.Sin(x * settings.Period + periosOffset) * settings.Amplitude) + y;

                    if (dy >= 0 && dy < height)
                    {
                        tgtBmp.SetPixel(dx, dy, color);
                    }
                }
            }

            // save to buffer
            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                tgtBmp.Save(ms, ImageFormat.Png);
                buffer = ms.GetBuffer();
            }

            // release
            srcBmp.Dispose();
            srcGraphics.Dispose();
            tgtBmp.Dispose();
            tgtGraphics.Dispose();

            #endregion

            return buffer;
        }
    }

    public class CaptchaSettings
    {
        public Font Font { get; set; }

        public Color ForeColor { get; set; }

        public Color BackColor { get; set; }

        public double Period { get; set; }

        public double Amplitude { get; set; }

        public CaptchaSettings()
        {
            Font = new Font("Arial", 12);
            ForeColor = Color.Black;
            BackColor = Color.White;
            Period = 0.1;
            Amplitude = 5;
        }
    }
}
