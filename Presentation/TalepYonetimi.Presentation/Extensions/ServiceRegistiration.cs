using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.AbstractRepositories.Departments;
using TalepYonetimi.Persistence.ConcreteRepositories.ApplicationUsers;
using TalepYonetimi.Persistence.ConcreteRepositories.Customers;
using TalepYonetimi.Persistence.ConcreteRepositories.Demands;
using TalepYonetimi.Persistence.ConcreteRepositories.Departments;

namespace TalepYonetimi.Presentation.Extensions
{
    public static class ServiceRegistiration
    {
        public static void AddServicesForRepositories(this IServiceCollection services)
        {
            // repository injection yönlendirmesi

            // program.cs de karışıklık ve kalabalık yapmaması adına, single responsibility ye uymak için extension static class ile service
            // register işlemini buraya aldım.

            // gelen istek doğrultusunda oluşturulan servis kapsamı dependency injectionda 3 ayrı metodda yaşam sürelerine göre ayrılır.
            // addScoped bunlardan biridir. bu fonksiyonda gelen her istekte yeni bir instance oluşturulur.

            services.AddScoped<IDemandReadRepository, DemandReadRepository>(); // IDemandReadRepository kullandığım yerde bana DemandReadRepository yi getir demiş oluyoruz.
            services.AddScoped<IDemandWriteRepository, DemandWriteRepository>();
            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IApplicationUserReadRepository, ApplicationUserReadRepository>();
            services.AddScoped<IApplicationUserWriteRepository, ApplicationUserWriteRepository>();
        }
    }
}
