using System;
using Xunit;
using Shouldly;
using ColorDisplay.Web.DataModels;

namespace ColorDisplay.Web.tests
{
    public class rgb_color_should
    {
        [Theory]
        [InlineData(255, 0,   0)]
        [InlineData(0,   0,   0)]
        [InlineData(255, 255, 255)]
        public void create_from_rgb_numbers(int r, int g, int b)
        {
            var rgbColor = new RgbColor(r, g, b);

            rgbColor.R.ShouldBe(r);
            rgbColor.G.ShouldBe(g);
            rgbColor.B.ShouldBe(b);
        }

        [Theory]
        [InlineData(255, 0,   0)]
        [InlineData(0,   0,   0)]
        [InlineData(255, 255, 255)]
        public void format_color_string(int r, int g, int b)
        {
            var rgbColor = new RgbColor(r, g, b);

            rgbColor.ColorString.ShouldBe($"rgb({r}, {g}, {b})");
        }

        [Theory]
        [InlineData(255, 0,   0,   "ff0000")]
        [InlineData(0,   0,   0,   "000000")]
        [InlineData(255, 255, 255, "ffffff")]
        [InlineData(71,  134, 153, "478699")]
        public void convert_rgb_to_hex(int r, int g, int b, string hexString)
        {
            var rgbColor = new RgbColor(r, g, b);
            var hexColor = rgbColor.ToHex();
            hexColor.ColorString.ShouldBe(hexString);
        }

        [Theory]
        [InlineData("rgb(255, 0, 0)", 255, 0, 0)]
        [InlineData("rgb(0, 0, 0)", 0, 0, 0)]
        [InlineData("rgb(255, 255, 255)", 255, 255, 255)]
        [InlineData("rgb(71,  134, 153)", 71,  134, 153)]
        public void convert_rgb_string_to_parts(string rgbColorString, int r, int g, int b)
        {
            var rgbColor = RgbColor.GetRgbFromColorString(rgbColorString);
            rgbColor.r.ShouldBe(r);
            rgbColor.g.ShouldBe(g);
            rgbColor.b.ShouldBe(b);
        }

        //[Theory]
        //[InlineData(253.0, 0.366, 0.439, "478699")]
        //public void test123(double h, double s, double v, string hexString)
        //{
        //    var hsvColor = new HsvColor(h, s, v);
        //    hsvColor.ColorString.ShouldBe($"hsv({h}, {s}, {v})");

        //    var tetradic0HsvColor = hsvColor.Tetradic0();
        //    tetradic0HsvColor.ColorString.ShouldBe($"hsv(193.9, 0.536, 0.6)");

        //    //var tetradic0RgbColor = tetradic0HsvColor.ToRgb();

        //    //var tetradic0HexColor = tetradic0RgbColor.ToHex();

        //    //tetradic0HexColor.ColorString.ShouldBe(hexString);


        //}
    }
}
