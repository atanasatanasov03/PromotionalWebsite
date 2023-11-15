using Microsoft.Extensions.Options;
using RooftopRepairs.Interfaces;
using RooftopRepairs.Models;
using System.Net;
using System.Net.Mail;

namespace RooftopRepairs.Services
{
    public class EmailService : IEmailService
    {
        private readonly IOptionsService _options;
        public EmailService(IOptionsService options)
        {
            _options = options;
        }
        public void sendEmail(InquiryViewModel model)
        {
            var fromAddress = new MailAddress(_options.GetOptions().Address, "TeslaRooftopRepair");
            var toAddress = new MailAddress("naskata088@gmail.com", "agne");
            string fromPassword = _options.GetOptions().AppPassword;
            string subject = model.subject;
            string body = model.message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = "Изпратено от: " + model.name + '\n' + "Имейл адрес: " + model.email + '\n' + "Съобщение: " + body + '\n' + "Изпратено на: " + DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")
            })
            {
                smtp.Send(message);
            }
        }
    }
}
