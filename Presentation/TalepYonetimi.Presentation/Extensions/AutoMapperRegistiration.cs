using TalepYonetimi.Application.MappingProfiles;

namespace TalepYonetimi.Presentation.Extensions
{
    public static class AutoMapperRegistiration
    {
        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            // Automapper 4. adım profiles registiration
            // artık dto lar kullanıma hazır oluyor. service lerde kullanabiliriz.
            services.AddAutoMapper(typeof(DemandMappingProfile));
            services.AddAutoMapper(typeof(DepartmentMappingProfile));
            services.AddAutoMapper(typeof(CustomerMappingProfile));
            services.AddAutoMapper(typeof(ApplicationUserMappingProfile));
            services.AddAutoMapper(typeof(CreateCustomerCommandMappingProfile));
        }
    }
}
