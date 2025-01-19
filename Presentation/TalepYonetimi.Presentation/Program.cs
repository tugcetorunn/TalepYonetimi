using Microsoft.EntityFrameworkCore;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Persistence.Contexts;
using TalepYonetimi.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// identity 3. ad�m
// identity service entegrasyonu 
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<TalepYonetimiDbContext>();

// db connection
builder.Services.AddDbContext<TalepYonetimiDbContext>(options => options
                                                           .UseSqlServer(builder.Configuration
                                                           .GetConnectionString("TalepYonetimiConnection"), // connectionString appSettings.json da configure edildi.
                                                           b => b.MigrationsAssembly("TalepYonetimi.Presentation")));

// repository extension metodun �a�r�lmas�
builder.Services.AddServicesForRepositories();

// automapper extension metodun �a�r�lmas�
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
    pattern: "{controller=Department}/{action=Index}/{id?}");

app.Run();
