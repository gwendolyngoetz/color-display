using System;
using System.Collections.Generic;
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
            HexColor = color.HexColor.ColorString;
            RgbColorString = color.RgbColor.ColorString;
            HsvColorString = color.HsvColor.ColorString;
            HslColorString = color.HslColor.ColorString;

            DecimalR = color.HexColor.DecimalR;
            DecimalG = color.HexColor.DecimalG;
            DecimalB = color.HexColor.DecimalB;

            OctalR = color.HexColor.OctalR;
            OctalG = color.HexColor.OctalG;
            OctalB = color.HexColor.OctalB;

            BinaryR = color.HexColor.BinaryR;
            BinaryG = color.HexColor.BinaryG;
            BinaryB = color.HexColor.BinaryB;

            HexR = color.HexColor.R;
            HexG = color.HexColor.G;
            HexB = color.HexColor.B;

            ComplementaryHexColor = color.ComplementaryHexColor.ColorString;

            Triadic0HexColor = color.Triadic0HexColor.ColorString;
            Triadic1HexColor = color.Triadic1HexColor.ColorString;

            Tetradic0HexColor = color.Tetradic0HexColor.ColorString;
            Tetradic1HexColor = color.Tetradic1HexColor.ColorString;
            Tetradic2HexColor = color.Tetradic2HexColor.ColorString;

            Square0HexColor = color.Square0HexColor.ColorString;
            Square1HexColor = color.Square1HexColor.ColorString;
            Square2HexColor = color.Square2HexColor.ColorString;

            Analagous0HexColor = color.Analagous0HexColor.ColorString;
            Analagous1HexColor = color.Analagous1HexColor.ColorString;

            Tints = color.Tints.Select(x => x.ColorString).ToArray();
            Shades = color.Shades.Select(x => x.ColorString).ToArray();
        }
    }
}
