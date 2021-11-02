using System;
using System.Text;

namespace ColorDisplay.Web.DataModels
{
    public class HsvColor
    {
        public double H { get; }
        public double S { get; }
        public double V { get; }

        public HsvColor(double h, double s, double v)
        {
            H = h;
            S = s;
            V = v;
        }

        public string ColorString => ToHsvColorString();

        public string ToHsvColorString()
        {
            var h = Math.Round(H, 1);
            var s = Math.Round(S, 3) * 100;
            var v = Math.Round(V, 3) * 100;

            return $"hsv({h}°, {s}%, {v}%)";
        }

        public HsvColor ComplementaryColor()
        {
            var newH = Math.Round((H + 180.0) % 360, 1);

            return new HsvColor(newH, S, V);
        }

        public HsvColor Triadic0()
        {
            var newH = (H + 120) % 360;

            return new HsvColor(newH, S, V);
        }

        public HsvColor Triadic1()
        {
            var newH = (H + 240) % 360;

            return new HsvColor(newH, S, V);
        }

        public HsvColor Tetradic0()
        {
            var newH = (H + 60.0) % 360;
            return new HsvColor(newH, S, V);
        }

        public HsvColor Tetradic1()
        {
            return ComplementaryColor();
        }

        public HsvColor Tetradic2()
        {
            var newHC = Tetradic0();
            return newHC.ComplementaryColor();
        }

        public HsvColor Square0()
        {
            var newH = (H + 90.0) % 360;

            return new HsvColor(newH, S, V);
        }

        public HsvColor Square1()
        {
            return ComplementaryColor();
        }

        public HsvColor Square2()
        {
            var newH = Math.Round((H + 270.0) % 360, 1);

            return new HsvColor(newH, S, V);
        }

        public HsvColor Analagous0()
        {
            var newH = (H + 30) % 360;

            return new HsvColor(newH, S, V);
        }

        public HsvColor Analagous1()
        {
            var newH = (H + -30) % 360;

            return new HsvColor(newH, S, V);
        }


        public RgbColor ToRgb()
        {
            // ######################################################################
            // T. Nathan Mundhenk
            // mundhenk@usc.edu
            // C/C++ Macro HSV to RGB

            int r;
            int g;
            int b;

            double H1 = this.H;
            while (H1 < 0) { H1 += 360; };
            while (H1 >= 360) { H1 -= 360; };

            double R, G, B;
            if (this.V <= 0)
            { 
                R = G = B = 0; 
            }
            else if (this.S <= 0)
            {
                R = G = B = this.V;
            }
            else
            {
                double hf = H1 / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = this.V * (1 - this.S);
                double qv = this.V * (1 - this.S * f);
                double tv = this.V * (1 - this.S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = this.V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = this.V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = this.V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = this.V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = this.V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = this.V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = this.V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = this.V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = this.V; // Just pretend its black/white
                        break;
                }
            }
                
            int Clamp(int i)
            {
                if (i < 0) return 0;
                if (i > 255) return 255;
                return i;
            }

            //r = Clamp((int)(R * 255.0));
            //g = Clamp((int)(G * 255.0));
            //b = Clamp((int)(B * 255.0));

            r = Clamp((int)Math.Round(R * 255.0));
            g = Clamp((int)Math.Round(G * 255.0));
            b = Clamp((int)Math.Round(B * 255.0));

            return new RgbColor(r, g, b);
        }
    }
}
