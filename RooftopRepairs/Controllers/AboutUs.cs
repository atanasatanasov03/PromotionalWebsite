using Microsoft.AspNetCore.Mvc;

namespace RooftopRepairs.Controllers
{
    public class AboutUs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
