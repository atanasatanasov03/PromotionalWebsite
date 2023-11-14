namespace RooftopRepairs.Models
{
    public class SingleServiceModel
    {
        public ServiceModel? service { get; set; }
        public InquiryModel inquiry { get; set; }
        public SingleServiceModel(ServiceModel _service, InquiryModel _inquiry)
        {
            service = _service;
            inquiry = _inquiry;
        }
        public SingleServiceModel() { }
    }
}
