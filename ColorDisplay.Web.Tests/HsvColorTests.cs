using System;
using Xunit;
using Shouldly;
using ColorDisplay.Web.DataModels;

namespace ColorDisplay.Web.tests
{
    public class hsv_color_should
    {
        [Theory]
        [InlineData(255, 0,   0)]
        [InlineData(0,   0,   0)]
        [InlineData(255, 255, 255)]
        public void create_from_hsl_numbers(double h, double s, double v)
        {
            var hsvColor = new HsvColor(h, s, v);

            hsvColor.H.ShouldBe(h);
            hsvColor.S.ShouldBe(s);
            hsvColor.V.ShouldBe(v);
        }

        [Theory]
        [InlineData(255, 0,   0)]
        [InlineData(0,   0,   0)]
        [InlineData(255, 255, 255)]
        [InlineData(253.902, 0.536, 0.6)]
        [InlineData(0, 0, 1)]
        [InlineData(193.9, 0.536, 0.6)]
        public void format_color_string(double h, double s, double v)
        {
            var hsvColor = new HsvColor(h, s, v);

            hsvColor.ColorString.ShouldBe($"hsv({Math.Round(h, 1)}°, {s*100}%, {v*100}%)");
        }



        [Theory]
        [InlineData(253.902, 0.536, 0.6, 90, 71, 153)]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 1, 255, 255, 255)]
        [InlineData(193.9, 0.536, 0.6, 71, 134, 153)]
        public void convert_hsv_to_rgb(double h, double s, double v, int r, int g, int b)
        {
            var hsvColor = new HsvColor(h, s, v);
            var rgbColor = hsvColor.ToRgb();

            rgbColor.R.ShouldBe(r);
            rgbColor.G.ShouldBe(g);
            rgbColor.B.ShouldBe(b);
        }

        [Theory]
        [InlineData(253.9, 0.536, 0.6, 313.9, 0.536, 0.6)]
        public void calculate_tetradic_0(double h, double s, double v, double th, double ts, double tv)
        {
            var hsvColor = new HsvColor(h, s, v);
            var tatradicHsvColor = hsvColor.Tetradic0();

            tatradicHsvColor.H.ShouldBe(th);
            tatradicHsvColor.S.ShouldBe(ts);
            tatradicHsvColor.V.ShouldBe(tv);
        }

        [Theory]
        [InlineData(253.9, 0.536, 0.6, 73.9, 0.536, 0.6)]
        public void calculate_tetradic_1(double h, double s, double v, double th, double ts, double tv)
        {
            var hsvColor = new HsvColor(h, s, v);
            var tatradicHsvColor = hsvColor.Tetradic1();

            tatradicHsvColor.H.ShouldBe(th);
            tatradicHsvColor.S.ShouldBe(ts);
            tatradicHsvColor.V.ShouldBe(tv);
        }

        [Theory]
        [InlineData(253.9, 0.536, 0.6, 133.9, 0.536, 0.6)]
        public void calculate_tetradic_2(double h, double s, double v, double th, double ts, double tv)
        {
            var hsvColor = new HsvColor(h, s, v);
            var tatradicHsvColor = hsvColor.Tetradic2();

            tatradicHsvColor.H.ShouldBe(th);
            tatradicHsvColor.S.ShouldBe(ts);
            tatradicHsvColor.V.ShouldBe(tv);
        }



        [Theory]
        [InlineData(253.9, 0.536, 0.6, 343.9, 0.536, 0.6)]
        public void calculate_square_0(double h, double s, double v, double th, double ts, double tv)
        {
            var hsvColor = new HsvColor(h, s, v);
            var tatradicHsvColor = hsvColor.Square0();

            tatradicHsvColor.H.ShouldBe(th);
            tatradicHsvColor.S.ShouldBe(ts);
            tatradicHsvColor.V.ShouldBe(tv);
        }

        [Theory]
        [InlineData(253.9, 0.536, 0.6, 73.9, 0.536, 0.6)]
        public void calculate_square_1(double h, double s, double v, double th, double ts, double tv)
        {
            var hsvColor = new HsvColor(h, s, v);
            var tatradicHsvColor = hsvColor.Square1();

            tatradicHsvColor.H.ShouldBe(th);
            tatradicHsvColor.S.ShouldBe(ts);
            tatradicHsvColor.V.ShouldBe(tv);
        }

        [Theory]
        [InlineData(253.9, 0.536, 0.6, 163.9, 0.536, 0.6)]
        public void calculate_square_2(double h, double s, double v, double th, double ts, double tv)
        {
            var hsvColor = new HsvColor(h, s, v);
            var tatradicHsvColor = hsvColor.Square2();

            tatradicHsvColor.H.ShouldBe(th);
            tatradicHsvColor.S.ShouldBe(ts);
            tatradicHsvColor.V.ShouldBe(tv);
        }
    }
}
/*
 
 h = 254
 254 + 270 =  524
 
 */