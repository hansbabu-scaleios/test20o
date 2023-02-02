using AI.Finder.BE.Service.Helpers;

namespace AI.Finder.BE.Service.Configuration
{
    public static class FinderSetting{
        public  static TokenInfo GetTokenInfo(){
            return new TokenInfo{
                Key = Environment.GetEnvironmentVariable("key"),
                Issuer = Environment.GetEnvironmentVariable("Issuer"),
                Audience = Environment.GetEnvironmentVariable("Audience"),
                ExpiryTime = Environment.GetEnvironmentVariable("ExpiryTime"),
                RefreshTokenExpiry = Environment.GetEnvironmentVariable("RefreshTokenExpiry")
            };
        }
    }

}