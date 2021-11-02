using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ColorDisplay.Web.Models;
using ColorDisplay.Web.DataModels;

namespace ColorDisplay.Web.Controllers
{
    public class ColorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ColorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("color")]
        public IActionResult Index()
        {
            return RedirectToAction("Index", new {colorHex = "5a4799"});
        }

        [HttpGet]
        [Route("color/{colorHex}")]
        public IActionResult Index(string colorHex)
        {
            var hexColor = new HexColor(colorHex);
            var rgbColor = hexColor.ToRgb();
            var hsvColor = rgbColor.ToHsv();
            var hslColor = rgbColor.ToHsl();

            var complementaryRgbColor = hsvColor.ComplementaryColor().ToRgb();
            var complementaryHexColor = complementaryRgbColor.ToHex();

            var tints = rgbColor.GetTints(9).Select(x => x.ToHex());
            var shades = rgbColor.GetShades(9).Select(x => x.ToHex());

            var triadic0HexColor = hsvColor.Triadic0().ToRgb().ToHex();
            var triadic1HexColor = hsvColor.Triadic1().ToRgb().ToHex();

            var tetradic0HexColor = hsvColor.Tetradic0().ToRgb().ToHex();
            var tetradic1HexColor = hsvColor.Tetradic1().ToRgb().ToHex();
            var tetradic2HexColor = hsvColor.Tetradic2().ToRgb().ToHex();

            var square0HexColor = hsvColor.Square0().ToRgb().ToHex();
            var square1HexColor = hsvColor.Square1().ToRgb().ToHex();
            var square2HexColor = hsvColor.Square2().ToRgb().ToHex();

            var analagous0HexColor = hsvColor.Analagous0().ToRgb().ToHex();
            var analagous1HexColor = hsvColor.Analagous1().ToRgb().ToHex();

            return View(new ColorViewModel
            {
                HexColor = hexColor.ColorString,
                RgbColorString = rgbColor.ColorString,
                HsvColorString = hsvColor.ColorString,
                HslColorString = hslColor.ColorString,

                DecimalR = hexColor.DecimalR,
                DecimalG = hexColor.DecimalG,
                DecimalB = hexColor.DecimalB,

                OctalR = hexColor.OctalR,
                OctalG = hexColor.OctalG,
                OctalB = hexColor.OctalB,

                BinaryR = hexColor.BinaryR,
                BinaryG = hexColor.BinaryG,
                BinaryB = hexColor.BinaryB,

                HexR = hexColor.R,
                HexG = hexColor.G,
                HexB = hexColor.B,

                ComplementaryHexColor = complementaryHexColor.ColorString,

                Triadic0HexColor = triadic0HexColor.ColorString,
                Triadic1HexColor = triadic1HexColor.ColorString,

                Tetradic0HexColor = tetradic0HexColor.ColorString,
                Tetradic1HexColor = tetradic1HexColor.ColorString,
                Tetradic2HexColor = tetradic2HexColor.ColorString,

                Square0HexColor = square0HexColor.ColorString,
                Square1HexColor = square1HexColor.ColorString,
                Square2HexColor = square2HexColor.ColorString,

                Analagous0HexColor = analagous0HexColor.ColorString,
                Analagous1HexColor = analagous1HexColor.ColorString,

                Tints = tints.Select(x => x.ColorString).ToArray(),
                Shades = shades.Select(x => x.ColorString).ToArray(),
            });
        }
    }
}
