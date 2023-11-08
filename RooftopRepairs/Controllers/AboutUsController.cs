using Microsoft.AspNetCore.Mvc;
using RooftopRepairs.Firestore;

namespace RooftopRepairs.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IFireService _fs;
        public AboutUsController(IFireService fs)
        {
            _fs = fs;
        }
        public IActionResult Index()
        {
            return View(_fs.getAboutUsImgs());
        }
    }
}
