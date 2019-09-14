using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SquadraExperience.Web.Models;
using SquadraExperience.Web.Service;

namespace SquadraExperience.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDogService _service;

        public HomeController(IDogService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var dog = await _service.GetRandomImage("dingo");

            ViewBag.ImageUrl = dog.Message;

            return View();
        }

        public IActionResult Privacy()
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
