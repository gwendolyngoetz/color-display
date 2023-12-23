using System.Collections.Generic;
using System.Linq;
using ColorDisplay.Web.DataModels;

namespace ColorDisplay.Web.DataModel
{
   public class ColorInformation
   {
        public Color Color { get; private set; }
        public Color Complementary { get; private set; }
        public TriadicColorGroup Triadic { get; private set; }
        public TetradicColorGroup Tetradic { get; private set; }
        public SquareColorGroup Square { get; private set; }
        public AnalogousColorGroup Analogous { get; private set; }
        public IEnumerable<Color> Tints { get; private set; } = new List<Color>();
        public IEnumerable<Color> Shades { get; private set; } = new List<Color>();

        public ColorInformation(HexColor hexColor)
        {
            Color = new Color(hexColor.ColorString);
            LoadRelatedColors();
        }

        public ColorInformation(RgbColor rgbColor)
        {
            Color = new Color(rgbColor.R, rgbColor.G, rgbColor.B);
            LoadRelatedColors();
        }

        public void LoadRelatedColors()
        {
            var hsvColor = Color.HSV;

            Complementary = new Color(hsvColor.ComplementaryColor().ToRgb().ToHex().ColorString);

            Triadic = new TriadicColorGroup(
                new Color(hsvColor.Triadic0().ToRgb().ToHex().ColorString),
                new Color(hsvColor.Triadic1().ToRgb().ToHex().ColorString)
            );

            Tetradic = new TetradicColorGroup(
                new Color(hsvColor.Tetradic0().ToRgb().ToHex().ColorString),
                new Color(hsvColor.Tetradic1().ToRgb().ToHex().ColorString),
                new Color(hsvColor.Tetradic2().ToRgb().ToHex().ColorString)
            );

            Square = new SquareColorGroup(
                new Color(hsvColor.Square0().ToRgb().ToHex().ColorString),
                new Color(hsvColor.Square1().ToRgb().ToHex().ColorString),
                new Color(hsvColor.Square2().ToRgb().ToHex().ColorString)
            );

            Analogous = new AnalogousColorGroup(
                new Color(hsvColor.Analagous0().ToRgb().ToHex().ColorString),
                new Color(hsvColor.Analagous1().ToRgb().ToHex().ColorString)
            );

            Tints = hsvColor.ToRgb().GetTints(9).Select(x => new Color(x.ToHex().ColorString));
            Shades = hsvColor.ToRgb().GetShades(9).Select(x => new Color(x.ToHex().ColorString));
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
