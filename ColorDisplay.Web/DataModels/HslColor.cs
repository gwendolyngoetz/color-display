using System;

namespace ColorDisplay.Web.DataModels
{
    public class HslColor 
    {
        public double H { get; }
        public double S { get; }
        public double L { get; }

        public string ColorString => ToHsvColorString();

        public string ToHsvColorString()
        {
            var h = Math.Round(H, 1);
            var s = Math.Round(S, 3) * 100;
            var l = Math.Round(L, 3) * 100;

            return $"hsl({h}°, {s}%, {l}%)";
        }

        public HslColor(double h, double s, double l)
        {
            H = h;
            S = s;
            L = l;
        }

        public HslColor(RgbColor rgbColor)
        {
            var converted = RgbToHsl(rgbColor);
            H = converted.h;
            S = converted.s;
            L = converted.l;
        }

        internal (double h, double s, double l) RgbToHsl(RgbColor rgbColor)
        {
            double hue = default;
            double saturation = default;
            double lightness = default;

            double r = (rgbColor.R / 255.0);
            double g = (rgbColor.G / 255.0);
            double b = (rgbColor.B / 255.0);

            double min = Math.Min(Math.Min(r, g), b);
            double max = Math.Max(Math.Max(r, g), b);
            double delta = max - min;

            lightness = (max + min) / 2;

            if (delta == 0)
            {
                hue = 0;
                saturation = 0.0;
            }
            else
            {
                saturation = (lightness <= 0.5) ? (delta / (max + min)) : (delta / (2.0 - max - min));
                
                if (r == max)
                {
                    hue = ((g - b) / 6) / delta;
                }
                else if (g == max)
                {
                    hue = (1.0 / 3) + ((b - r) / 6) / delta;
                }
                else
                {
                    hue = (2.0 / 3) + ((r - g) / 6) / delta;
                }

                if (hue < 0)
                {
                    hue += 1;
                }

                if (hue > 1)
                {
                    hue -= 1;
                }
            
                hue = Math.Round(hue * 360, 1);
            }

            return (hue, saturation, lightness);
        }
    }
}
