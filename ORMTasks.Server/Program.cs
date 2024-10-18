using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using ORM.Models;
using ORM.Services; // Asegúrate de que la ruta sea correcta
using ORMTasks.Server; // Asegúrate de incluir el espacio de nombres para TablerService

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la conexión al DbContext
builder.Services.AddDbContext<ORMDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 0, 1))));

// Registrar PasswordHasher para gestionar contraseñas
builder.Services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();

// Registrar UserService
builder.Services.AddScoped<UserService>();

// Registrar TablerService
builder.Services.AddScoped<TablerService>(); // Asegúrate de añadir esta línea

builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

var app = builder.Build();

// CORS
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Archivos estáticos para el frontend
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Redirigir las rutas no encontradas al index.html (para Angular)
app.MapFallbackToFile("/index.html");

app.Run();
