namespace RooftopRepairs.Models
{
    public class ImageModel
    {
        private string? _url;
        private string? _desc;
        public string? getUrl() { return _url; }
        public string? getDesc() { return _desc; }
        public void setUrl(string? url) {
            if(url == null) throw new ArgumentNullException("Null Image URL");
            if (!ValidUrl(url)) throw new ArgumentException("Not a valid URL");
            if(!FirebaseUrl(url)) throw new ArgumentException("Not a Firebase URL");

            _url = url;
        }
        public void setDesc(string? desc) {
            if(desc == null) throw new ArgumentNullException("Null Image Description");
            if(ValidUrl(desc)) throw new ArgumentException("Invalid Description");

            _desc = desc;
        }
        private static bool ValidUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
        private static bool FirebaseUrl(string url)
        {
            return url.Contains(".googleapis.");
        }
    }
}
