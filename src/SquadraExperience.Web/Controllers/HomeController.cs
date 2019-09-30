using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement.Mvc;
using SquadraExperience.Web.Models;
using SquadraExperience.Web.Service;

namespace SquadraExperience.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDogService _service;
        private readonly IHostingEnvironment _hosting;
        private DogConfiguration _dogConfig;
       

        public HomeController(IDogService service, IHostingEnvironment hosting, IOptionsSnapshot<DogConfiguration> config)
        {
            _service = service;
            _hosting = hosting;
            _dogConfig = config.Value;
        }

        public async Task<IActionResult> Index()
        {
            var dog = await _service.GetRandomImage(_dogConfig.DogName);
            ViewBag.Dog = _dogConfig.DogName;
            ViewBag.ImageUrl = dog.Message;
            ViewBag.Env = _hosting.EnvironmentName;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [FeatureGate("Beta")]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
