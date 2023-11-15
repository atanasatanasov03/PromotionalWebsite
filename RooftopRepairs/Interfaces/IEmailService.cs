using RooftopRepairs.Models;

namespace RooftopRepairs.Interfaces
{
    public interface IEmailService
    {
        public void sendEmail(InquiryViewModel model);
    }
}
