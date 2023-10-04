using Microsoft.AspNetCore.Mvc;

namespace RooftopRepairs.Controllers
{
    public class Gallery : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
