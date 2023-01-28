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



}

