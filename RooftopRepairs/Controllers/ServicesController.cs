using Microsoft.AspNetCore.Mvc;
using RooftopRepairs.Models;

namespace RooftopRepairs.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            List<ServiceModel> roofServices = new List<ServiceModel>() {
                new ServiceModel("Подмяна на керемиди", new List<string> { "Почистване на онсовата", "Полагане на покривно фолио", "Монтаж на самозалепващи битумни керемиди" }, "61,50"),
                new ServiceModel("Пренареждане на керемиди", new List<string> { "Полагане на паропропусклива мембрана", "Монтаж на двоина скара от летви 4/3", "Редене на керемиди и капаци", "Измазване на капаци с варов циментов разтвор" }, "25,00"),
                new ServiceModel("Смяна на стари керемиди", new List<string> { "Разкриване на старите елементи и почистване на основата", "Полагане на паропропусклива мембрана и монтаж на двоина скара от летви", "Редене на керемиди и капаци и измазване с варов циментов разтвор" }, "75,00"),
                new ServiceModel("Хидроизолация", new List<string> { "Почистване и грундиране на основата, отстраняване на покривни язви", "Сваляне на филц от покрива или преместване от една страна на друга", "Почистване на старата хидроизолация и извозване на строителни отпадъци", "Залепване на хидроизолация със или без посипка" }, "45,00")
            };
            List<ServiceModel> tinsmithingServices = new List<ServiceModel>() {
                new ServiceModel("Подмяна на капандури", new List<string> { "Демонтаж на стар улук", "Поставяне на скоби", "Монтаж на нов улук"}, "25,00"),
                new ServiceModel("Подулучни и надулучни поли", new List<string> { "Демонтаж на стар улук", "Поставяне на скоби", "Монтаж на нов улук" }, "25,00"),
                new ServiceModel("Подмяна на улуци", new List<string> { "Демонтаж на стар улук", "Поставяне на скоби", "Монтаж на нов улук" }, "25,00"),
                new ServiceModel("Обшивки", new List<string> { "на комини", "на бордове", "подулучни/надулучни поли" }, "по договаряне")
            };
            List<ServiceModel> buildingRoofs = new List<ServiceModel>() { 
                new ServiceModel("Нова покривна конструкция", new List<string> { "Демонтаж на старите керемиди, капаци, ламарини улуци и дървена конструкция", "Изграждане на нова конструкция с греди", "Оребяване на покрива", "Наковаване на дървена ламперия с дебелината на дъските", "Монтаж на Челни Дъски" }, "85,00"),
                new ServiceModel("Надстройка на таванска стая", new List<string> { "Разкриване и почистване на старата конструкция", "Надзид на постройката", "Изграждане на нова конструкция", "Наковаване и лакиране на челни дъски", "Наковаване и лакиране на сачак", "Наковаване на дъсчена ламперия", "Извозване на отпадъци"}, "95,00"),
                new ServiceModel("Сух монтаж на капаци", new List<string> { "Монтаж на билна летва", "Полагане на самозалепваща лента с алуминиево фолио", "Редене на капаци и захващане със винт и щипка за капак"}, "70,00"),
                new ServiceModel("Изграждане на тухлен надзид", new List<string> { "С тухли четворка и варов циментов разтвор"}, "75,00"),
                new ServiceModel("Изграждане на бетонен пояс", new List<string> { "Куфражни дъски", "Армировка от желязо", "Бетон Б 25"}, "75,00"),
                
            };
            List<ServiceModel> buildingChimneys = new List<ServiceModel>() { 
                new ServiceModel("Измазване на комин", new List<string> { "С варов циментов разтвор" }, "По договаряне"),
                new ServiceModel("Изграждане на бетонена шапка", new List<string> { "Куфражни дъски", "Армировка от желязо", "Бетон Б 25"}, "75,00"),
            };
            List<ServiceModel> buildingGazebo = new List<ServiceModel>() { 
                new ServiceModel("Изграждане на беседка или навес", new List<string> { "Топлоизолация по желание" }, "По договаряне")
            };

            Dictionary<string, List<ServiceModel>> model = new Dictionary<string, List<ServiceModel>>();
            model["Ремон на покриви и хидроизолация"] = roofServices;
            model["Тенекеджийство"] = tinsmithingServices;
            model["Изграждане на покриви"] = buildingRoofs;
            model["Изграждане на комини"] = buildingChimneys;
            model["Беседки и навеси"] = buildingGazebo;
            
            return View(model);
        }
        
        public IActionResult Single(string id)
        {
            return View(id);
        }
    }
}
