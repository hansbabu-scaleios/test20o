using AI.Finder.BE.Service.Helpers.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace AI.Finder.BE.Service.Features.User.Authentication;
[ApiController]
[Route("[Controller]")]
[Authorize]
public class AuthController : ControllerBase
{
    private readonly FinderDbContext context;
    public AuthController(FinderDbContext context)
    {
        this.context = context;
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> PostLogIn([FromBody] AuthRequestDTO req){
        try{
            var expiryDate = Environment.GetEnvironmentVariable("ExpiryTime");
            var user = await context.Users
                           .Where(e => e.UserId == req.UserId)
                           .FirstOrDefaultAsync();
            if (user == null){
                return BadRequest();
            }
            if (AuthenticationManager.IsPasswordVerified(user.PassowrdSalt, user.PasswordHash, req.Password) == true){

                return Ok(new AuthResponseDto
                {
                    Success = true,
                    Token = new JwtSecurityTokenHandler().WriteToken(JwtManager.GenerateJwtToken(user.UserId, expiryDate))
                });
            }
            else{
                return BadRequest();
            }
        }
        catch (Exception ex){
            return BadRequest(ex);
        }
    }
    [HttpGet("RefreshToken")]
    [AllowAnonymous]
    public  IActionResult RefreshToken(){
        try{
            JwtClaimsValue userIdentity = JwtManager.DecodeGeneratedToKen(HttpContext);
            var RefreshexpiryDate = Environment.GetEnvironmentVariable("RefreshTokenExpiry");
            if (userIdentity == null)
            {
                return BadRequest();
            }
            JwtManager.GenerateJwtToken(userIdentity.UserId, RefreshexpiryDate);
             return  Ok(new AuthResponseDto
            {
                Success = true,
                Token = new JwtSecurityTokenHandler().WriteToken(JwtManager.GenerateJwtToken(userIdentity.UserId, RefreshexpiryDate))
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

}

