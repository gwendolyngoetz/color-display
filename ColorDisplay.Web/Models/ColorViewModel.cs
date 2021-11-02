using System;
using System.Collections.Generic;
using ColorDisplay.Web.DataModels;

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
    }
}
