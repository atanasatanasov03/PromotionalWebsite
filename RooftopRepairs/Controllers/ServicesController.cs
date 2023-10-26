using Microsoft.AspNetCore.Mvc;

namespace RooftopRepairs.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            string m = new("Вид ремонт");
            return View(model: m);
        }
    }
}
