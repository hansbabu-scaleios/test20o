namespace AI.Finder.BE.Service.Helpers.JWT
{
    public class JwtClaimsValue
    {
        public string UserId { get; set; }
        public string Role { get; set; }
        public string Rolecode { get; set; }

        public DateTime ExpiryDate{ get; set;}
    }
}