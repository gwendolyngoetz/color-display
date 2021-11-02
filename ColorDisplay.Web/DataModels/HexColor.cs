using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ColorDisplay.Web.DataModels
{
    public class HexColor 
    {
        private static Regex _hexColorPattern = new Regex("^#?([A-Fa-f0-9]{6})$");

        public string R { get; }
        public string G { get; }
        public string B { get; }

        public int DecimalR => Convert.ToInt32(R, 16);
        public int DecimalG => Convert.ToInt32(G, 16);
        public int DecimalB => Convert.ToInt32(B, 16);

        public string OctalR => Convert.ToString(DecimalR, 8);
        public string OctalG => Convert.ToString(DecimalG, 8);
        public string OctalB => Convert.ToString(DecimalB, 8);

        public string BinaryR => Convert.ToString(DecimalR, 2).PadLeft(8, '0');
        public string BinaryG => Convert.ToString(DecimalG, 2).PadLeft(8, '0');
        public string BinaryB => Convert.ToString(DecimalB, 2).PadLeft(8, '0');

        public string ColorString => ToHexString();

        public HexColor(int r, int g, int b)
        {
            R = r.ToString("X2").ToLower();
            G = g.ToString("X2").ToLower();
            B = b.ToString("X2").ToLower();
        }

        public HexColor(string hexString)
        {
            hexString = hexString.Replace("#", "").ToLower();

            R = hexString.Substring(0, 2);
            G = hexString.Substring(2, 2);
            B = hexString.Substring(4, 2);
        }

        public static bool IsHexCode(string hexColor)
        {
            if (string.IsNullOrWhiteSpace(hexColor))
            {
                return false;
            }

            return _hexColorPattern.IsMatch(hexColor);
        }

        private string ToHexString()
        {
            var sb = new StringBuilder();
            
            // Red
            if (R.Length == 1)
            {
                sb.Append("0");
            }

            sb.Append(R);

            // Green
            if (G.Length == 1)
            {
                sb.Append("0");
            }

            sb.Append(G);

            // Blue
            if (B.Length == 1)
            {
                sb.Append("0");
            }

            sb.Append(B);

            return sb.ToString();
        }
    
        public RgbColor ToRgb()
        {
            var r = Convert.ToInt32(R, 16);
            var g = Convert.ToInt32(G, 16);
            var b = Convert.ToInt32(B, 16);

            return new RgbColor(r, g, b);
        }
    }
}
