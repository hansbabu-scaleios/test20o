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
    private readonly FinderDbContext _context;
    public AuthController(FinderDbContext context){
        _context = context;
    }
     [HttpPost("login")]
     [AllowAnonymous]
    public async Task<IActionResult> PostLogIn([FromBody] AuthRequestDTO req){
        try{
            var user = await _context.Users
                           .Where(e => e.UserId == req.UserId)
                           .FirstOrDefaultAsync();
            if (user == null){
                return BadRequest();
            }
//TODO: Add salt and password
            if (AuthenticationManager.IsPasswordVerified(user.PassowrdSalt,user.PasswordHash,req.Password) == true){

                return Ok(new AuthResponseDto { Success = true, Token = new JwtSecurityTokenHandler().WriteToken(JwtManager.GenerateJwtToken(user)) });
            }
            else {
                return BadRequest();
            }
        }
        catch (Exception ex){
            return BadRequest(ex);
        }
    }
}

