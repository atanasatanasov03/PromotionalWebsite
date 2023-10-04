using Microsoft.AspNetCore.Mvc;

namespace RooftopRepairs.Controllers
{
    public class Services : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
