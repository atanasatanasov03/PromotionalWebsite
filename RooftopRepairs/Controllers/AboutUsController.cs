using Microsoft.AspNetCore.Mvc;

namespace RooftopRepairs.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
