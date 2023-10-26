using Microsoft.AspNetCore.Mvc;
using RooftopRepairs.Firestore;
using RooftopRepairs.Models;
using System.Diagnostics;

namespace RooftopRepairs.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFireService _fs;

        public HomeController(IFireService fs)
        {
            _fs = fs;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Admin()
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