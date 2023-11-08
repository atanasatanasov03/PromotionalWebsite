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
            while(!_fs.Loaded()) { }
            return View(_fs.getHomeImgs());
        }
    }
}