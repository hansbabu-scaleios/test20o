using AI.Finder.BE.Service.Helpers.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AI.Finder.BE.Service.Features.User.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AI.Finder.BE.Service.Features.User.Authentication;
[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly FinderDbContext _context;
    private readonly IConfiguration _configuration;
    public AuthenticationController(FinderDbContext context,IConfiguration configuration)
    {
        _context = context;
        _configuration=configuration;
    }
     [HttpGet("{username}")]
    public async Task<IActionResult> LogIn(string username, string password){
        try{
            var user = await _context.Users
                           .Where(e => e.UserId == username)
                           .FirstOrDefaultAsync();
            if (user == null){
                return BadRequest();
            }
            if (AuthenticationManager.IsPasswordVerified(user,password) == true){


                return Ok(JwtManager.GenerateJwtToken(user,_configuration));
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

