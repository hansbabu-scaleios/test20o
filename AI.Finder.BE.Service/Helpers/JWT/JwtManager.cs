using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AI.Finder.BE.Service.Helpers.JWT;
public class JwtManager
{
    public static JwtSecurityToken GenerateJwtToken(string UserId,string ExpiryDate)
    {
        var claims = new[]{
                       new Claim(JwtClaimConstants.UserId, UserId),
                       new Claim(JwtClaimConstants.RoleCode,"1" ),
                       new Claim(JwtClaimConstants.Role,"Admin"),
                    };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key")));
        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new  JwtSecurityToken (
                       Environment.GetEnvironmentVariable("Issuer"),
                       Environment.GetEnvironmentVariable("Audience"),
                       claims,
                       expires: DateTime.Now.AddMinutes(Convert.ToInt32(ExpiryDate)),
                       signingCredentials: credential
                    );
        return   token;
    }
    public  static   JwtClaimsValue DecodeGeneratedToKen(HttpContext context)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", String.Empty);
        var token =  tokenHandler.ReadJwtToken(tokenString);
       return  (new JwtClaimsValue
        {
            UserId = token.Claims.First(c => c.Type == "userid").Value,
            RoleName = token.Claims.First(c => c.Type == "rolename").Value,
            Rolecode = token.Claims.First(c => c.Type == "rolecode").Value
        });
    }
}


