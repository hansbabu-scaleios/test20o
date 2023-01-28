namespace AI.Finder.BE.Service.Helpers.JWT
{
    public class JWT
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
        public string ExpiryTime{get;set;}
    }
}