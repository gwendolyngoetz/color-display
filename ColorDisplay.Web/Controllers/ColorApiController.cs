using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ColorDisplay.Web.DataModel;

namespace ColorDisplay.Web.Controllers
{
    public class ColorApiController : Controller 
    {
        private readonly ILogger<ColorApiController> _logger;

        public ColorApiController(ILogger<ColorApiController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("api/colors/{colorString}")]
        public IActionResult Index(string colorString)
        {
            var color = ColorLoader.Instance.GetColor(colorString);
            return Json(color);
        }
    }
}
