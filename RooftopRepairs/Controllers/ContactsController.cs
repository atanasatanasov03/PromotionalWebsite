using Microsoft.AspNetCore.Mvc;
using RooftopRepairs.Models;
using System.Net.Mail;
using System.Net;
using RooftopRepairs.Helpers;
using Google.Cloud.Firestore;
using NToastNotify;
using RooftopRepairs.Interfaces;

namespace RooftopRepairs.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly IToastNotification _toastNotification;
        public ContactsController(IEmailService emailSerice, IToastNotification toastNotification)
        {
            _emailService = emailSerice;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(InquiryViewModel model)
        {
            Console.WriteLine(model.subject + '\n' + model.message);

            if (ModelState.IsValid)
            {
                _emailService.sendEmail(model);
                _toastNotification.AddSuccessToastMessage("Съобщението бе изпратено успешно");
                ModelState.Clear();
            } else _toastNotification.AddErrorToastMessage("Моля попълнете правилно всички полета");
            return Index();
        }
        
    }
}
