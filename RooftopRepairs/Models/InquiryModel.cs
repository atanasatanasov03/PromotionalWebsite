using System.ComponentModel.DataAnnotations;

namespace RooftopRepairs.Models
{
    public class InquiryModel
    {
        [Required]
        [StringLength(120, MinimumLength = 3)]
        public string name { get; set; }
        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string subject { get; set; }
        [Required]
        [StringLength (2500, MinimumLength = 10)]
        public string message { get; set; }
        public void clear ()
        {
            name = string.Empty;
            email = string.Empty;
            subject = string.Empty;
            message = string.Empty;
        }
        public InquiryModel(string name, string email, string subject, string message)
        {
            this.name = name;
            this.email = email;
            this.subject = subject;
            this.message = message;
        }
        public InquiryModel(string subject)
        {
            clear();
            this.subject = subject;
        }
        public InquiryModel() { }
    }
}
