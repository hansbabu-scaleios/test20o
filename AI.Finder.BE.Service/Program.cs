using System.Text;
using AI.Finder.BE.Service;
using AI.Finder.BE.Service.Helpers.ErrorHandling;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;

var builder = WebApplication.CreateBuilder(args);

    var root = Directory.GetCurrentDirectory();
    var dotenv = Path.Combine(root, ".env");
    DotNetEnv.Env.Load(dotenv);

//builder.Services.AddSingleton<TokenInfo>(FinderSetting.GetTokenInfo());



builder.Services.AddDbContext<FinderDbContext>(options =>
{
    options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString"));
});
// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddControllers().AddJsonOptions(option=>{option.JsonSerializerOptions.PropertyNamingPolicy=null;});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(document => 
{
    document.Title = "FinderAPI";
    document.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
    {
        In = OpenApiSecurityApiKeyLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        Type = OpenApiSecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer",
    });
    document.OperationProcessors.Add(
        new AspNetCoreOperationSecurityScopeProcessor("JWT"));
    });

//implimentation azure insight
builder.Services.AddApplicationInsightsTelemetry();

//implimentation of jwt token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
    options.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Environment.GetEnvironmentVariable("Issuer"),
        ValidAudience = Environment.GetEnvironmentVariable("Audience"),
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key")))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
