using Xunit;
using Shouldly;
using ColorDisplay.Web.DataModel;
using ColorDisplay.Web.DataModels;
using ColorDisplay.Web.Models;

namespace ColorDisplay.Web.tests
{
    public class color_view_model_should
    {
        [Theory]
        [InlineData("5a4799")]
        [InlineData("rgb(90, 71, 153)")]
        public void colorloader_rgb_colorstring_is_correct(string colorString)
        {
            var color = ColorLoader.Instance.GetColor(colorString);
            color.Color.RGB.R.ShouldBe(90);
            color.Color.RGB.G.ShouldBe(71);
            color.Color.RGB.B.ShouldBe(153);
            color.Color.RGB.ColorString.ShouldBe("rgb(90, 71, 153)");
        }

        [Theory]
        [InlineData("5a4799")]
        [InlineData("rgb(90, 71, 153)")]
        public void colorviewmodel_rgbcolorstring_is_correct(string colorString)
        {
            var color = ColorLoader.Instance.GetColor(colorString);
            var view = new ColorViewModel(color);
            view.RgbColorString.ShouldBe("rgb(90, 71, 153)");
        }

        [Theory]
        [InlineData("rgb(90, 71, 153)")]
        public void rgbcolor_colorstring_is_correct(string colorString)
        {
           var rgbColor = RgbColor.Parse(colorString);
           rgbColor.ColorString.ShouldBe("rgb(90, 71, 153)");
        }
    }
}
