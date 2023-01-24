using AI.Finder.BE.Service;
using AI.Finder.BE.Service.Helpers.ErrorHandling;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinderDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<ExceptionHandlingMiddleware>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
   {
       c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finder API V1");
       c.RoutePrefix = string.Empty;
       c.DefaultModelsExpandDepth(-1);
   });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
