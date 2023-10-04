using Microsoft.AspNetCore.Mvc;

namespace RooftopRepairs.Controllers
{
    public class Contacts : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
