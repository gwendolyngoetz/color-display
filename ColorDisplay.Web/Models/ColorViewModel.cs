using System.Linq;
using ColorDisplay.Web.DataModel;

namespace ColorDisplay.Web.Models
{
    public class ColorViewModel
    {
        public string HexColor { get; set; }
        public string RgbColorString { get; set; }
        public string HslColorString { get; set; }
        public string HsvColorString { get; set; }

        public int DecimalR { get; set; }
        public int DecimalG { get; set; }
        public int DecimalB { get; set; }

        public string OctalR { get; set; }
        public string OctalG { get; set; }
        public string OctalB { get; set; }

        public string BinaryR { get; set; }
        public string BinaryG { get; set; }
        public string BinaryB { get; set; }

        public string HexR { get; set; }
        public string HexG { get; set; }
        public string HexB { get; set; }

        public string ComplementaryHexColor { get; set; }

        public string Triadic0HexColor { get; set; }
        public string Triadic1HexColor { get; set; }

        public string Tetradic0HexColor { get; set; }
        public string Tetradic1HexColor { get; set; }
        public string Tetradic2HexColor { get; set; }

        public string Square0HexColor { get; set; }
        public string Square1HexColor { get; set; }
        public string Square2HexColor { get; set; }

        public string Analagous0HexColor { get; set; }
        public string Analagous1HexColor { get; set; }

        public string[] Tints { get; set; }
        public string[] Shades { get; set; }

        public ColorViewModel(ColorInformation color)
        {
            HexColor = color.Color.Hex.ColorString;
            RgbColorString = color.Color.RGB.ColorString;
            HsvColorString = color.Color.HSV.ColorString;
            HslColorString = color.Color.HSL.ColorString;

            DecimalR = color.Color.Hex.DecimalR;
            DecimalG = color.Color.Hex.DecimalG;
            DecimalB = color.Color.Hex.DecimalB;

            OctalR = color.Color.Hex.OctalR;
            OctalG = color.Color.Hex.OctalG;
            OctalB = color.Color.Hex.OctalB;

            BinaryR = color.Color.Hex.BinaryR;
            BinaryG = color.Color.Hex.BinaryG;
            BinaryB = color.Color.Hex.BinaryB;

            HexR = color.Color.Hex.R;
            HexG = color.Color.Hex.G;
            HexB = color.Color.Hex.B;

            ComplementaryHexColor = color.Complementary.Hex.ColorString;

            Triadic0HexColor = color.Triadic.Triadic0.Hex.ColorString;
            Triadic1HexColor = color.Triadic.Triadic1.Hex.ColorString;

            Tetradic0HexColor = color.Tetradic.Tetradic0.Hex.ColorString;
            Tetradic1HexColor = color.Tetradic.Tetradic1.Hex.ColorString;
            Tetradic2HexColor = color.Tetradic.Tetradic2.Hex.ColorString;

            Square0HexColor = color.Square.Square0.Hex.ColorString;
            Square1HexColor = color.Square.Square1.Hex.ColorString;
            Square2HexColor = color.Square.Square2.Hex.ColorString;

            Analagous0HexColor = color.Analogous.Analogous0.Hex.ColorString;
            Analagous1HexColor = color.Analogous.Analogous1.Hex.ColorString;

            Tints = color.Tints.Select(x => x.Hex.ColorString).ToArray();
            Shades = color.Shades.Select(x => x.Hex.ColorString).ToArray();
        }
    }
}
