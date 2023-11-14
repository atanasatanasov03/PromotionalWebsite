using System;

namespace RooftopRepairs.Models
{
    public class ServiceModel
    {
        private static Random random = new Random();
        public string id { get; set; }
        public string serviceName { get; set; }
        public List<string> serviceDesc { get; set; }
        public string servicePrice { get; set; }
        public string key { get; set; }
        public ServiceModel() { }
        public ServiceModel(string serviceName, List<string> serviceDesc, string servicePrice, string key)
        {
            id = RandomString(7);
            this.serviceName = serviceName;
            this.serviceDesc = serviceDesc;
            this.servicePrice = servicePrice;
            this.key = key;
        }

        private static string RandomString(int length)
        {
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < length; i++)
            {
                randValue = random.Next(0, 26);
                
                letter = Convert.ToChar(randValue + 65);
                
                str = str + letter;
            }

            return str;
        }
    }
}
