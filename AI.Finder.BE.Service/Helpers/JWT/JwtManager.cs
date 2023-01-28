using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AI.Finder.BE.Service.Features.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AI.Finder.BE.Service.Helpers.JWT;
public class JwtManager
{
    public static string GenerateJwtToken(UserModel user, IConfiguration _configuration)
    {
        var jwt = _configuration.GetSection("Jwt").Get<JWT>();
        var claims = new[]{
                       new Claim(JwtClaimConstants.UserId, user.UserId),
                       new Claim(JwtClaimConstants.RoleCode,"1" ),
                       new Claim(JwtClaimConstants.RoleName,"Admin"),
                    };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
                       jwt.Issuer,
                       jwt.Audience,
                       claims,
                       expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwt.ExpiryTime)),
                       signingCredentials: credential
                    );
        return (new JwtSecurityTokenHandler().WriteToken(token));
    }
    }


