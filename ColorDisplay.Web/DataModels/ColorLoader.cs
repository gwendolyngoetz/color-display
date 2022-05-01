using System.Collections.Generic;
using System.Linq;
using ColorDisplay.Web.DataModels;

namespace ColorDisplay.Web.DataModel
{
   public class ColorInformation
   {
        public HexColor HexColor { get; private set; }
        public RgbColor RgbColor { get; private set; }
        public HsvColor HsvColor { get; private set; }
        public HslColor HslColor { get; private set; }

        public HexColor ComplementaryHexColor { get; private set; }

        public HexColor Triadic0HexColor { get; private set; }
        public HexColor Triadic1HexColor { get; private set; }

        public HexColor Tetradic0HexColor { get; private set; }
        public HexColor Tetradic1HexColor { get; private set; }
        public HexColor Tetradic2HexColor { get; private set; }

        public HexColor Square0HexColor { get; private set; }
        public HexColor Square1HexColor { get; private set; }
        public HexColor Square2HexColor { get; private set; }

        public HexColor Analagous0HexColor { get; private set; }
        public HexColor Analagous1HexColor { get; private set; }

        public IEnumerable<HexColor> Tints { get; private set; } = new List<HexColor>();
        public IEnumerable<HexColor> Shades { get; private set; } = new List<HexColor>();

        public ColorInformation(HexColor hexColor)
        {
            HexColor = hexColor;
            RgbColor = HexColor.ToRgb();
            HsvColor = RgbColor.ToHsv();
            HslColor = RgbColor.ToHsl();

            LoadRelatedColors();
        }

        public ColorInformation(RgbColor rgbColor)
        {
            RgbColor = rgbColor;
            HexColor = RgbColor.ToHex();
            HsvColor = RgbColor.ToHsv();
            HslColor = RgbColor.ToHsl();

            LoadRelatedColors();
        }

        public void LoadRelatedColors()
        {
            ComplementaryHexColor = HsvColor.ComplementaryColor().ToRgb().ToHex();

            Triadic0HexColor = HsvColor.Triadic0().ToRgb().ToHex();
            Triadic1HexColor = HsvColor.Triadic1().ToRgb().ToHex();

            Tetradic0HexColor = HsvColor.Tetradic0().ToRgb().ToHex();
            Tetradic1HexColor = HsvColor.Tetradic1().ToRgb().ToHex();
            Tetradic2HexColor = HsvColor.Tetradic2().ToRgb().ToHex();

            Square0HexColor = HsvColor.Square0().ToRgb().ToHex();
            Square1HexColor = HsvColor.Square1().ToRgb().ToHex();
            Square2HexColor = HsvColor.Square2().ToRgb().ToHex();

            Analagous0HexColor = HsvColor.Analagous0().ToRgb().ToHex();
            Analagous1HexColor = HsvColor.Analagous1().ToRgb().ToHex();

            Tints = RgbColor.GetTints(9).Select(x => x.ToHex());
            Shades = RgbColor.GetShades(9).Select(x => x.ToHex());
        }
   }
    
   public class ColorLoader
   {
       public static ColorLoader Instance { get; } = new ColorLoader();

       public ColorInformation GetColor(string colorString)
       {
           if (colorString.Contains("rgb"))
           {
               return GetColorByRgb(colorString);
           }

           return GetColorByHex(colorString);
       }

       private ColorInformation GetColorByHex(string colorHexString)
       {
           var hexColor = new HexColor(colorHexString);
           return new ColorInformation(hexColor);
       }

       private ColorInformation GetColorByRgb(string colorRgbString)
       {
           var rgbColor = RgbColor.Parse(colorRgbString);
           return new ColorInformation(rgbColor);
       }
   }
}
