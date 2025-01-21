using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TalepYonetimi.Application.Concretes;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Persistence.Contexts;
using TalepYonetimi.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// api controller 1. ad�m
builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

// swagger 1. ad�m swashbuckle paketini y�kle
// swagger 2. ad�m
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// identity 3. ad�m
// identity service entegrasyonu 
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    // signIn configure ayarlar�
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 5;

}).AddEntityFrameworkStores<TalepYonetimiDbContext>();

builder.Services.Configure<IdentityOptions>(options => options.Password.RequireNonAlphanumeric = false);

// db connection
builder.Services.AddDbContext<TalepYonetimiDbContext>(options => options
                                                           .UseSqlServer(builder.Configuration
                                                           .GetConnectionString("TalepYonetimiConnection"), // connectionString appSettings.json da configure edildi.
                                                           b => b.MigrationsAssembly("TalepYonetimi.Presentation")));

// repository extension metodun �a�r�lmas�
builder.Services.AddServicesForRepositories();

// automapper extension metodun �a�r�lmas�
builder.Services.AddAutoMapperProfiles();

// mediatr extension metodun �a�r�lmas�
builder.Services.AddMediatrServices();

// jwt authorization 1. ad�m (yetkilendirme konusu i�in jwt token mekanizmas�n� kullan�yorum)
// Microsoft.AspNetCore.Authentication.JwtBearer k�t�phanesi presentationa y�klenir.
// jwt 2. ad�m
// authentication service eklenmesi bu k�s�m token do�rulama ile ilgilidir. bir de handler ile token �retme yap�yoruz. iki tarafta da issuer, audience bilgilerimiz bulunuyor. bunlar birbiriyle e�le�meli ki do�rulama yap�labilsin.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options => // uygulamaya token �zerinden istek geldi�inde bunun jwt oldu�unu bildiriyoruz
                                                  // ve a�a��daki ayarlamalar �zerinden jwt do�rulanacak. jwt yerine oauth, cookie ile de authentication yap�labilir.
{
    options.TokenValidationParameters = new() // gelen token da hangi de�erlere bak�laca�� bilgisi i�in
    {
        // true ile bunlar�n do�rulanmas� gerekti�ini s�yl�yoruz.
        ValidateIssuer = true, // token � olu�turan taraf (client)
        ValidateAudience = true, // token �n hedef kitlesi (api/endpoint)
        ValidateLifetime = true, // token s�resi
        ValidateIssuerSigningKey = true, // token � imzalamak i�in kullan�lan anahtar�n do�rulu�unu kontrol eder. (secretkey) g�venli�i sa�lamak i�in zorunlu aland�r.

        // token �retme k�sm�nda da bu �zellikler tan�mlanarak buradaki de�erlerle kar��la�t�r�l�p do�rulanacak;
        ValidAudience = builder.Configuration.GetSection("JWT:Audience").Get<string>(),
        ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Get<string>(),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:SecurityKey").Get<string>())), // token imzalanmas� i�in kullan�lan key i veriyoruz. token �n ge�erli olup olmad���n� kontrol eder.
    };
}); // scheme ("Admin") -> birden fazla panelde authentication yap�lan projeler i�in schema ay�r�c� �zelliktir. bizde �uan sadece adminde authencation yap�l�yor.

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// role olu�turma metodunun �al��t�r�lmas�
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var configuration = services.GetRequiredService<IConfiguration>();
    await UserRoleHandler.AddingUserRole(services, configuration);
}

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}


app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // wwwroot taki dosyalar� kullan�ma haz�r hale getirir.

// jwt 3. ad�m service in kullan�l�r hale gelmesi
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // api controller'lar�n� buradan y�nlendirir

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Demand}/{action=Create}/{id?}");

app.Run();
