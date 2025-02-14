using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StamingRobot.Repository.Entities;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("app-cors",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination")
            .AllowAnyMethod();
        });
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddDbContext<StampingRobotContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("StampingRobot"))
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stamping Robot API v.01");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health");

app.UseCors("app-cors");

app.Run();
