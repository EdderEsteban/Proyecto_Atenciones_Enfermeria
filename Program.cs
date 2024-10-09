using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Proyecto_Atenciones_Enfermeria.Data;
using Proyecto_Atenciones_Enfermeria.Models;
using Proyecto_Atenciones_Enfermeria.Repositorios; 

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container. 
builder.Services.AddControllersWithViews();

/* PARA MySql - usando Pomelo */
builder.Services.AddDbContext<DataContext>(
    options => options.UseMySql(
        configuration["ConnectionStrings:DefaultConnection"],
        ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"])
    )
);

// Servicio de Autenticación
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>//el sitio web valida con cookie
    {
        options.LoginPath = "/Usuarios/Login";
        options.LogoutPath = "/Usuarios/Logout";
        options.AccessDeniedPath = "/Home/Restringido";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);//Tiempo de expiración
    });

// Políticas de Autorización
builder.Services.AddAuthorization(options =>
{
    // Política para Administradores
    options.AddPolicy("Administrador", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Administrador"));

    // Política para Director
    options.AddPolicy("Director", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Director"));

    // Política combinada para Enfermero
    options.AddPolicy("Enfermero", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Enfermero"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Usar autenticacion y autorizacion
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
