using System;
using Xunit;
using Shouldly;
using ColorDisplay.Web.DataModels;

namespace ColorDisplay.Web.tests
{
    public class hsl_color_should
    {
        [Theory]
        [InlineData(255, 0,   0)]
        [InlineData(0,   0,   0)]
        [InlineData(255, 255, 255)]
        public void create_from_hsl_numbers(double h, double s, double l)
        {
            var hslColor = new HslColor(h, s, l);

            hslColor.H.ShouldBe(h);
            hslColor.S.ShouldBe(s);
            hslColor.L.ShouldBe(l);
        }

        [Theory]
        [InlineData(255, 0,   0)]
        [InlineData(0,   0,   0)]
        [InlineData(255, 255, 255)]
        public void format_color_string(double h, double s, double l)
        {
            var hslColor = new HslColor(h, s, l);

            hslColor.ColorString.ShouldBe($"hsl({h}°, {s*100}%, {l*100}%)");
        }
    }
}
