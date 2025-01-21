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

// api controller 1. adým
builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

// swagger 1. adým swashbuckle paketini yükle
// swagger 2. adým
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// identity 3. adým
// identity service entegrasyonu 
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    // signIn configure ayarlarý
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

// repository extension metodun çaðrýlmasý
builder.Services.AddServicesForRepositories();

// automapper extension metodun çaðrýlmasý
builder.Services.AddAutoMapperProfiles();

// mediatr extension metodun çaðrýlmasý
builder.Services.AddMediatrServices();

// jwt authorization 1. adým (yetkilendirme konusu için jwt token mekanizmasýný kullanýyorum)
// Microsoft.AspNetCore.Authentication.JwtBearer kütüphanesi presentationa yüklenir.
// jwt 2. adým
// authentication service eklenmesi bu kýsým token doðrulama ile ilgilidir. bir de handler ile token üretme yapýyoruz. iki tarafta da issuer, audience bilgilerimiz bulunuyor. bunlar birbiriyle eþleþmeli ki doðrulama yapýlabilsin.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options => // uygulamaya token üzerinden istek geldiðinde bunun jwt olduðunu bildiriyoruz
                                                  // ve aþaðýdaki ayarlamalar üzerinden jwt doðrulanacak. jwt yerine oauth, cookie ile de authentication yapýlabilir.
{
    options.TokenValidationParameters = new() // gelen token da hangi deðerlere bakýlacaðý bilgisi için
    {
        // true ile bunlarýn doðrulanmasý gerektiðini söylüyoruz.
        ValidateIssuer = true, // token ý oluþturan taraf (client)
        ValidateAudience = true, // token ýn hedef kitlesi (api/endpoint)
        ValidateLifetime = true, // token süresi
        ValidateIssuerSigningKey = true, // token ý imzalamak için kullanýlan anahtarýn doðruluðunu kontrol eder. (secretkey) güvenliði saðlamak için zorunlu alandýr.

        // token üretme kýsmýnda da bu özellikler tanýmlanarak buradaki deðerlerle karþýlaþtýrýlýp doðrulanacak;
        ValidAudience = builder.Configuration.GetSection("JWT:Audience").Get<string>(),
        ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Get<string>(),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:SecurityKey").Get<string>())), // token imzalanmasý için kullanýlan key i veriyoruz. token ýn geçerli olup olmadýðýný kontrol eder.
    };
}); // scheme ("Admin") -> birden fazla panelde authentication yapýlan projeler için schema ayýrýcý özelliktir. bizde þuan sadece adminde authencation yapýlýyor.

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// role oluþturma metodunun çalýþtýrýlmasý
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
app.UseStaticFiles(); // wwwroot taki dosyalarý kullanýma hazýr hale getirir.

// jwt 3. adým service in kullanýlýr hale gelmesi
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // api controller'larýný buradan yönlendirir

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Demand}/{action=Create}/{id?}");

app.Run();
