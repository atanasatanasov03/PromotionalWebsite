using System;

namespace RooftopRepairs.Models
{
    public class ServiceModel
    {
        private static Random random = new Random();
        public string serviceName { get; set; }
        public List<string> serviceDesc { get; set; }
        public string servicePrice { get; set; }
        public string id { get; set; }

        public ServiceModel(string serviceName, List<string> serviceDesc, string servicePrice)
        {
            this.serviceName = serviceName;
            this.serviceDesc = serviceDesc;
            this.servicePrice = servicePrice;
            id = RandomString(7);
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
