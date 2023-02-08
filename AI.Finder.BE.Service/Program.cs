using System.Text;
using AI.Finder.BE.Service;
using AI.Finder.BE.Service.Configuration;
using AI.Finder.BE.Service.Helpers.ErrorHandling;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;

var builder = WebApplication.CreateBuilder(args);
//Loading configuration from environmental variable
// TODO: Refactor the code 
var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotNetEnv.Env.Load(dotenv);
// TODO: Load appsettings.json to FinderSettings class
//builder.Services.AddSingleton<TokenInfo>(FinderSetting.GetTokenInfo());
var services = builder.Services;
services.AddDbContext<FinderDbContext>(options => options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Environment.GetEnvironmentVariable("Issuer"),
        ValidAudience = Environment.GetEnvironmentVariable("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("key")))
    };
});
// Add services to the container.
builder.Services.AddControllers();//.AddJsonOptions(option => { option.JsonSerializerOptions.PropertyNamingPolicy = null; });
services.AddResponseCompression();
// Open Api 
services.AddSwaggerDocument(document =>
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
services.AddHttpClient();
services.AddCors();
services.AddAuthorization();
var app = builder.Build();
//builder.Services.AddEndpointsApiExplorer();
//implimentation ofjwt token
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    app.UseOpenApi();
    app.UseSwaggerUi3();
}
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(c =>
{
    _=c.AllowAnyHeader();
    _=c.AllowAnyMethod();
    _=c.AllowAnyOrigin();
});
try
{
    app.Run();
    return 0;
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    return 1;
}

