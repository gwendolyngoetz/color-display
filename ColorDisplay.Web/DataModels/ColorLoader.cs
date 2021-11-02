//using ColorDisplay.Web.DataModels;

//namespace ColorDisplay.Web.DataModel
//{
//    public class ColorInformation
//    {
//        public HexColor HexColor { get; set; }
//        public RgbColor RgbColor { get; set; }
//        public HsvColor HsvColor { get; set; }
//        public HslColor HslColor { get; set; }

//        public HexColor ComplementaryHexColor { get; set; }

//        public HexColor Triadic0HexColor { get; set; }
//        public HexColor Triadic1HexColor { get; set; }

//        public HexColor Tetradic0HexColor { get; set; }
//        public HexColor Tetradic1HexColor { get; set; }
//        public HexColor Tetradic2HexColor { get; set; }

//        public HexColor Square0HexColor { get; set; }
//        public HexColor Square1HexColor { get; set; }
//        public HexColor Square2HexColor { get; set; }

//        public HexColor Analagous0HexColor { get; set; }
//        public HexColor Analagous1HexColor { get; set; }
//    }
    
//    public class ColorLoader
//    {
//        public static ColorLoader Instance { get; } = new ColorLoader();

//        public ColorInformation GetColor(string colorString)
//        {
//            if (colorString.Contains("rgb"))
//            {
//                return new ColorInformation();
//            }

//            return GetColorByHex(colorString);
//        }

//        private ColorInformation GetColorByHex(string colorHexString)
//        {
//            var hexColor = new HexColor(colorHexString);
//            var rgbColor = hexColor.ToRgb();
//            var hsvColor = rgbColor.ToHsv();
//            var hslColor = rgbColor.ToHsl();

//            var complementaryHexColor = hsvColor.ComplementaryColor().ToRgb().ToHex();

//            var triadic0HexColor = hsvColor.Triadic0().ToRgb().ToHex();
//            var triadic1HexColor = hsvColor.Triadic1().ToRgb().ToHex();

//            var tetradic0HexColor = hsvColor.Tetradic0().ToRgb().ToHex();
//            var tetradic1HexColor = hsvColor.Tetradic1().ToRgb().ToHex();
//            var tetradic2HexColor = hsvColor.Tetradic2().ToRgb().ToHex();

//            var square0HexColor = hsvColor.Square0().ToRgb().ToHex();
//            var square1HexColor = hsvColor.Square1().ToRgb().ToHex();
//            var square2HexColor = hsvColor.Square2().ToRgb().ToHex();

//            var analagous0HexColor = hsvColor.Analagous0().ToRgb().ToHex();
//            var analagous1HexColor = hsvColor.Analagous1().ToRgb().ToHex();

//            return new ColorInformation
//            {
//                HexColor = hexColor,
//                RgbColor = rgbColor,
//                HsvColor = hsvColor,
//                HslColor = hslColor,

//                ComplementaryHexColor = complementaryHexColor,

//                Triadic0HexColor = triadic0HexColor,
//                Triadic1HexColor = triadic1HexColor,

//                Tetradic0HexColor = tetradic0HexColor,
//                Tetradic1HexColor = tetradic1HexColor,
//                Tetradic2HexColor = tetradic2HexColor,

//                Square0HexColor = square0HexColor,
//                Square1HexColor = square1HexColor,
//                Square2HexColor = square2HexColor,

//                Analagous0HexColor = analagous0HexColor,
//                Analagous1HexColor = analagous1HexColor,
//            };
//        }
//    }
//}
