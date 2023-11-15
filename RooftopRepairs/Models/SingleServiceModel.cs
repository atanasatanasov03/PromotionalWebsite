namespace RooftopRepairs.Models
{
    public class SingleServiceModel
    {
        public ServiceModel? service { get; set; }
        public InquiryViewModel inquiry { get; set; }
        public SingleServiceModel(ServiceModel _service, InquiryViewModel _inquiry)
        {
            service = _service;
            inquiry = _inquiry;
        }
        public SingleServiceModel() { }
    }
}
