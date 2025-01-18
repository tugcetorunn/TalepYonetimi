using Microsoft.EntityFrameworkCore;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.AbstractRepositories.Departments;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Persistence.ConcreteRepositories.ApplicationUsers;
using TalepYonetimi.Persistence.ConcreteRepositories.Customers;
using TalepYonetimi.Persistence.ConcreteRepositories.Demands;
using TalepYonetimi.Persistence.ConcreteRepositories.Departments;
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
    name: "default",
    pattern: "{controller=Demands}/{action=Index}/{id?}");

app.Run();
