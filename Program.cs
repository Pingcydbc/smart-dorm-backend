using Microsoft.EntityFrameworkCore;
using SmartDormApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAurelia",
        policy => policy.WithOrigins("http://localhost:9000")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseCors("AllowAurelia");

app.UseStaticFiles();

app.MapControllers();

app.Run();