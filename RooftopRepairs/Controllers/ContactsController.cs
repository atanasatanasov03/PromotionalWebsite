using Microsoft.AspNetCore.Mvc;

namespace RooftopRepairs.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
