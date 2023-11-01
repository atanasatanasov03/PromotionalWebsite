using Microsoft.AspNetCore.Mvc;

namespace RooftopRepairs.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            Dictionary<string, List<string>> model = new Dictionary<string, List<string>>();

            model.Add("С керемиди", new List<string>());
            model.Add("Пренареждане на керемиди", new List<string>());
            model["С керемиди"].Add("Почистване на основата");
            model["С керемиди"].Add("Полагане на покривно фолио");
            model["С керемиди"].Add("Монтаж на самозалепващи Битумни Керемиди");
            model["С керемиди"].Add("68,00лв/м²");

            model["Пренареждане на керемиди"].Add("Почистване на кал");
            model["Пренареждане на керемиди"].Add("Полагане на паро пропусклива мембрана за под керемиди");
            model["Пренареждане на керемиди"].Add("Монтаж на двоина скара от летви 4/3 вертикални и хоризонтални");
            model["Пренареждане на керемиди"].Add("Редене на съществуващи керемиди и капаци");
            model["Пренареждане на керемиди"].Add("Измазване на капаци с варов-циментов разтвор");
            model["Пренареждане на керемиди"].Add("Почистване и извозване на отпадъците");
            model["Пренареждане на керемиди"].Add("25,00 лв/м².");

            return View(model);
        }
        
        public IActionResult Service(string name)
        {
            Console.WriteLine("haha"+ name);
            return View(name);
        }
    }
}
