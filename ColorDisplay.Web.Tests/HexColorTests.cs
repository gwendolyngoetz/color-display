using Xunit;
using Shouldly;
using ColorDisplay.Web.DataModels;

namespace ColorDisplay.Web.tests
{
    public class hex_color_should
    {
        [Theory]
        [InlineData("#ff0000", "ff", "00", "00")]
        [InlineData("ff0000",  "ff", "00", "00")]
        [InlineData("000000",  "00", "00", "00")]
        [InlineData("ffffff",  "ff", "ff", "ff")]
        public void create_from_hex_string(string hexString, string r, string g, string b)
        {
            var hexColor = new HexColor(hexString);

            hexColor.R.ShouldBe(r);
            hexColor.G.ShouldBe(g);
            hexColor.B.ShouldBe(b);
        }

        [Theory]
        [InlineData(255, 0,   0,   "ff", "00", "00")]
        [InlineData(0,   0,   0,   "00", "00", "00")]
        [InlineData(255, 255, 255, "ff", "ff", "ff")]
        [InlineData(90,  71,  153, "5a", "47", "99")]
        public void create_from_rgb_values_string(int r, int g, int b, string hexR, string hexG, string hexB)
        {
            var hexColor = new HexColor(r, g, b);

            hexColor.R.ShouldBe(hexR);
            hexColor.G.ShouldBe(hexG);
            hexColor.B.ShouldBe(hexB);
        }

        [Theory]
        [InlineData("ff0000")]
        [InlineData("000000")]
        [InlineData("ffffff")]
        public void format_red_color_string(string hexString)
        {
            var hexColor = new HexColor(hexString);
            hexColor.ColorString.ShouldBe(hexString);
        }

        [Theory]
        [InlineData("ff0000", 255, 0,   0)]
        [InlineData("000000", 0,   0,   0)]
        [InlineData("ffffff", 255, 255, 255)]
        public void convert_hex_to_rgb(string hexString, int r, int g, int b)
        {
            var hexColor = new HexColor(hexString);
            var rgbColor = hexColor.ToRgb();

            rgbColor.R.ShouldBe(r);
            rgbColor.G.ShouldBe(g);
            rgbColor.B.ShouldBe(b);
        }

        [Theory]
        [InlineData("ff0000", true)]
        [InlineData("#ff0000", true)]
        [InlineData("fff", false)]
        [InlineData("00000g", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void is_string_valid_hex_color(string hexString, bool expected)
        {
            var actual = HexColor.IsHexCode(hexString);
            actual.ShouldBe(expected);
        }
    }
}
