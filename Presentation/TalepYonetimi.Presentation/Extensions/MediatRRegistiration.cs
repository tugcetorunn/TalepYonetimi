using MediatR;
using System.Reflection;
using TalepYonetimi.Application.Commands.ApplicationUsers;

namespace TalepYonetimi.Presentation.Extensions
{
    public static class MediatRRegistiration
    {
        public static void AddMediatrServices(this IServiceCollection services)
        {
            // mediatr 1. adım mediatr ve MediatR.Extensions.Microsoft.DependencyInjection projeye yüklenmesi
            // mediatr 2. adım dependency injection registiration
            // handlerlar için bulunduğu assembly deki (derleme) tüm MediatR handler sınıflarını bulmak ve kaydetmek için kullanılır.
            services.AddMediatR(typeof(CreateApplicationUserCommand).GetTypeInfo().Assembly); // bir tanesini kaydetmek yeterli.
        }
    }
}
