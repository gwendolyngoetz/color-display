using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorDisplay.Web.DataModels
{
    public class RgbColor
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }

        public string ColorString => $"rgb({R}, {G}, {B})";

        public RgbColor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static (int r, int g, int b) GetRgbFromColorString(string rgbColorString)
        {
            rgbColorString = rgbColorString.Replace("rgb(", "").Replace(")", "").Replace(" ", "");
            var split = rgbColorString.Split(',');
            var r = int.Parse(split[0].Trim());
            var g = int.Parse(split[1].Trim());
            var b = int.Parse(split[2].Trim());

            return (r, g, b);
        }

        public HexColor ToHex()
        {
            return new HexColor(R, G, B);
        }

        public HsvColor ToHsv()
        {
            double r = (double)R / 255;
            double g = (double)G / 255;
            double b = (double)B / 255;

            double h;
            double s;
            double v;

            double min = Math.Min(Math.Min(r, g), b);
            double max = Math.Max(Math.Max(r, g), b);
            v = max;
            double delta = max - min;
            if (max == 0 || delta == 0)
            {
                s = 0;
                h = 0;
            }
            else
            {
                s = delta / max;
                if (r == max)
                {
                    // Between Yellow and Magenta
                    h = (g - b) / delta;
                }
                else if (g == max)
                {
                    // Between Cyan and Yellow
                    h = 2 + (b - r) / delta;
                }
                else
                {
                    // Between Magenta and Cyan
                    h = 4 + (r - g) / delta;
                }

            }

            h *= 60;
            if (h < 0)
            {
                h += 360;
            }

            return new HsvColor(h, s, v);
        }

        public HslColor ToHsl()
        {
            return new HslColor(this);
        }
    
        public IEnumerable<RgbColor> GetTints(int numberOfTints)
        {
            var result = new List<RgbColor>();

            var tintRgbColor = new RgbColor(R, G, B);
            result.Add(tintRgbColor);

            for (int i = 0; i < numberOfTints - 1; i++)
            {

                var previousRgbColor = result.Last();
                var newR = previousRgbColor.R + (0.25 * (255 - previousRgbColor.R));
                var newG = previousRgbColor.G + (0.25 * (255 - previousRgbColor.G));
                var newB = previousRgbColor.B + (0.25 * (255 - previousRgbColor.B));
                var newTintRgbColor = new RgbColor((int)newR, (int)newG, (int)newB);

                result.Add(newTintRgbColor);
            }

            return result;
        }

        public IEnumerable<RgbColor> GetShades(int numberOfShades)
        {
            var result = new List<RgbColor>();

            var tintRgbColor = new RgbColor(R, G, B);
            result.Add(tintRgbColor);

            var shadeFactor = numberOfShades / 100.0;

            for (int i = 0; i < numberOfShades - 1; i++)
            {
                var previousRgbColor = result.Last();
                var newR = previousRgbColor.R - (previousRgbColor.R * shadeFactor);
                var newG = previousRgbColor.G - (previousRgbColor.G * shadeFactor);
                var newB = previousRgbColor.B - (previousRgbColor.B * shadeFactor);
                var newTintRgbColor = new RgbColor((int)newR, (int)newG, (int)newB);

                result.Add(newTintRgbColor);
            }

            result.Reverse();

            return result;
        }
    
        public static RgbColor Parse(string rgbColorString)
        {
            var (r, g, b) = GetRgbFromColorString(rgbColorString);
            return new RgbColor(r, g, b);
        }
    }
}
