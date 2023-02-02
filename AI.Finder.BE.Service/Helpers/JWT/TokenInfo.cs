namespace AI.Finder.BE.Service.Helpers;

    public class TokenInfo{
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ExpiryTime { get; set; }
        public string RefreshTokenExpiry { get; set; }
    }
