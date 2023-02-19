using System;
using System.Text;

namespace ColorDisplay.Web.DataModels
{
    public class Color 
    {
        public HexColor Hex { get; private set; }
        public HslColor HSL { get; private set; }
        public HsvColor HSV { get; private set; }
        public RgbColor RGB { get; private set; }

        public Color(string hexString)
        {
            Hex = new HexColor(hexString);
            RGB = Hex.ToRgb();
            HSL = RGB.ToHsl();
            HSV = RGB.ToHsv();
        }

        public Color(int r, int g, int b)
        {
            RGB = new RgbColor(r, g, b);
            Hex = RGB.ToHex();
            HSL = RGB.ToHsl();
            HSV = RGB.ToHsv();
        }
    }

    public class TriadicColorGroup 
    {
        public Color Triadic0 { get; private set; }
        public Color Triadic1 { get; private set; }

        public TriadicColorGroup(Color triadic0, Color triadic1)
        {
            Triadic0 = triadic0;
            Triadic1 = triadic1;
        }
    }

    public class TetradicColorGroup
    {
        public Color Tetradic0 { get; private set; }
        public Color Tetradic1 { get; private set; }
        public Color Tetradic2 { get; private set; }

        public TetradicColorGroup(Color tetradic0, Color tetradic1, Color tetradic2)
        {
            Tetradic0 = tetradic0;
            Tetradic1 = tetradic1;
            Tetradic2 = tetradic2;
        }
    }
    
    public class SquareColorGroup
    {
        public Color Square0 { get; private set; }
        public Color Square1 { get; private set; }
        public Color Square2 { get; private set; }

        public SquareColorGroup(Color square0, Color square1, Color square2)
        {
            Square0 = square0;
            Square1 = square1;
            Square2 = square2;
        }
    }

    public class AnalogousColorGroup 
    {
        public Color Analogous0 { get; private set; }
        public Color Analogous1 { get; private set; }

        public AnalogousColorGroup(Color analogous0, Color analogous1)
        {
            Analogous0 = analogous0;
            Analogous1 = analogous1;
        }
    }
}
