using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ColorDisplay.Web.Models;
using ColorDisplay.Web.DataModels;
using ColorDisplay.Web.DataModel;

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
            var color = ColorLoader.Instance.GetColor(colorHex);
            return View(new ColorViewModel(color));
        }
    }
}
