using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using RooftopRepairs.Interfaces;
using RooftopRepairs.Models;
using System.ComponentModel;
using System.Dynamic;

namespace RooftopRepairs.Controllers
{
    public class ServicesController : Controller
    {
        private static readonly Dictionary<string, List<ServiceModel>> _model = new Dictionary<string, List<ServiceModel>>();
        private readonly IEmailService _emailService;
        private readonly IToastNotification _toastNotification;
        public ServicesController(IEmailService emailService, IToastNotification toastNotification)
        {
            _emailService = emailService;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            List<string> keys = new List<string>() { "Ремон на покриви и хидроизолация", "Тенекеджийство", "Изграждане на покриви", "Изграждане на комини", "Беседки и навеси" };
            List<ServiceModel> roofServices = new List<ServiceModel>() {
                new ServiceModel("Подмяна на керемиди", new List<string> { "Почистване на онсовата", "Полагане на покривно фолио", "Монтаж на самозалепващи битумни керемиди" }, "61,50", keys[0]),
                new ServiceModel("Пренареждане на керемиди", new List<string> { "Полагане на паропропусклива мембрана", "Монтаж на двоина скара от летви 4/3", "Редене на керемиди и капаци", "Измазване на капаци с варов циментов разтвор" }, "25,00", keys[0]),
                new ServiceModel("Смяна на стари керемиди", new List<string> { "Разкриване на старите елементи и почистване на основата", "Полагане на паропропусклива мембрана и монтаж на двоина скара от летви", "Редене на керемиди и капаци и измазване с варов циментов разтвор" }, "75,00", keys[0]),
                new ServiceModel("Хидроизолация", new List<string> { "Почистване и грундиране на основата, отстраняване на покривни язви", "Сваляне на филц от покрива или преместване от една страна на друга", "Почистване на старата хидроизолация и извозване на строителни отпадъци", "Залепване на хидроизолация със или без посипка" }, "45,00", keys[0])
            };
            List<ServiceModel> tinsmithingServices = new List<ServiceModel>() {
                new ServiceModel("Подмяна на капандури", new List<string> { "Демонтаж на стар улук", "Поставяне на скоби", "Монтаж на нов улук"}, "25,00", keys[1]),
                new ServiceModel("Подулучни и надулучни поли", new List<string> { "Демонтаж на стар улук", "Поставяне на скоби", "Монтаж на нов улук" }, "25,00", keys[1]),
                new ServiceModel("Подмяна на улуци", new List<string> { "Демонтаж на стар улук", "Поставяне на скоби", "Монтаж на нов улук" }, "25,00", keys[1]),
                new ServiceModel("Обшивки", new List<string> { "на комини", "на бордове", "подулучни/надулучни поли" }, "по договаряне", keys[1])
            };
            List<ServiceModel> buildingRoofs = new List<ServiceModel>() { 
                new ServiceModel("Нова покривна конструкция", new List<string> { "Демонтаж на старите керемиди, капаци, ламарини улуци и дървена конструкция", "Изграждане на нова конструкция с греди", "Оребяване на покрива", "Наковаване на дървена ламперия с дебелината на дъските", "Монтаж на Челни Дъски" }, "85,00", keys[2]),
                new ServiceModel("Надстройка на таванска стая", new List<string> { "Разкриване и почистване на старата конструкция", "Надзид на постройката", "Изграждане на нова конструкция", "Наковаване и лакиране на челни дъски", "Наковаване и лакиране на сачак", "Наковаване на дъсчена ламперия", "Извозване на отпадъци"}, "95,00", keys[2]),
                new ServiceModel("Сух монтаж на капаци", new List<string> { "Монтаж на билна летва", "Полагане на самозалепваща лента с алуминиево фолио", "Редене на капаци и захващане със винт и щипка за капак"}, "70,00", keys[2]),
                new ServiceModel("Изграждане на тухлен надзид", new List<string> { "С тухли четворка и варов циментов разтвор"}, "75,00", keys[2]),
                new ServiceModel("Изграждане на бетонен пояс", new List<string> { "Куфражни дъски", "Армировка от желязо", "Бетон Б 25"}, "75,00", keys[2]),
                
            };
            List<ServiceModel> buildingChimneys = new List<ServiceModel>() { 
                new ServiceModel("Измазване на комин", new List<string> { "С варов циментов разтвор" }, "По договаряне", keys[3]),
                new ServiceModel("Изграждане на бетонена шапка", new List<string> { "Куфражни дъски", "Армировка от желязо", "Бетон Б 25"}, "75,00", keys[3]),
            };
            List<ServiceModel> buildingGazebo = new List<ServiceModel>() { 
                new ServiceModel("Изграждане на беседка или навес", new List<string> { "Топлоизолация по желание" }, "По договаряне", keys[4])
            };

            _model[keys[0]] = roofServices;
            _model[keys[1]] = tinsmithingServices;
            _model[keys[2]] = buildingRoofs;
            _model[keys[3]] = buildingChimneys;
            _model[keys[4]] = buildingGazebo;
            
            return View(_model);
        }

        [HttpGet]
        public IActionResult Single(string id, string key)
        {
            ServiceModel single = null;

            single = _model[key].Where(i => i.id == id).FirstOrDefault();

            if (single is not null)
            {
                SingleServiceModel model = new SingleServiceModel(single, new InquiryViewModel(single.serviceName));
                return View(model);
            }
            else
            {
                _toastNotification.AddErrorToastMessage("Нещо се обърка");
                return Index();
            }
        }
        [HttpPost]
        public IActionResult Inquire(SingleServiceModel mod)
        {
            if (ModelState.IsValid)
            {
                _emailService.sendEmail(mod.inquiry);
                _toastNotification.AddSuccessToastMessage("Съобщението бе изпратено успешно");
                mod.inquiry.clear();
            } else _toastNotification.AddErrorToastMessage("Моля попълнете правилно всички полета");
            return RedirectToAction("Single", new { mod.service.id, mod.service.key });
        }
    }
}
