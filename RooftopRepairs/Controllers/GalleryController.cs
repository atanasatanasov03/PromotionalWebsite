using Microsoft.AspNetCore.Mvc;
using RooftopRepairs.Interfaces;

namespace RooftopRepairs.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IFireService _fs;
        public GalleryController(IFireService fs)
        {
            _fs = fs;
        }
        public IActionResult Roofs()
        {
            return View("Index", _fs.getRoofImgs());
        }

        public IActionResult Waterproofing()
        {
            return View("Index", _fs.getWaterproofingImgs());
        }
        public IActionResult Building()
        {
            return View("Index", _fs.getBuildingImgs());
        }
    }
}
