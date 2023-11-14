using RooftopRepairs.Models;

namespace RooftopRepairs.Services
{
    public interface IEmailService
    {
        public void sendEmail (InquiryModel model);
    }
}
