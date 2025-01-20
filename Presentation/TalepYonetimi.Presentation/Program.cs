using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TalepYonetimi.Application.Commands.ApplicationUsers;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Persistence.Contexts;
using TalepYonetimi.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// identity 3. adým
// identity service entegrasyonu 
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<TalepYonetimiDbContext>();

// db connection
builder.Services.AddDbContext<TalepYonetimiDbContext>(options => options
                                                           .UseSqlServer(builder.Configuration
                                                           .GetConnectionString("TalepYonetimiConnection"), // connectionString appSettings.json da configure edildi.
                                                           b => b.MigrationsAssembly("TalepYonetimi.Presentation")));

// repository extension metodun çaðrýlmasý
builder.Services.AddServicesForRepositories();

// automapper extension metodun çaðrýlmasý
builder.Services.AddAutoMapperProfiles();

// mediatr extension metodun çaðrýlmasý
builder.Services.AddMediatrServices();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{controller=ApplicationUser}/{action=SignUp}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "Admin/{controller=ApplicationUser}/{action=SignUp}/{id?}");

app.Run();
