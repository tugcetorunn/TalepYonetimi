using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TalepYonetimi.Application.Commands.ApplicationUsers;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.ApplicationUsers
{
    public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand, CreateApplicationUserCommandResponse>
    {
        private readonly UserManager<ApplicationUser> userManager; // identity kütüphanesinden hazır gelen kullanıcı ile ilgili fonksiyonlar için
                                                                   // ioc ile inject ediyoruz.
        private readonly IMapper mapper;
        public CreateApplicationUserCommandHandler(UserManager<ApplicationUser> _userManager, IMapper _mapper)
        {
            userManager = _userManager;
            mapper = _mapper;
        }
        public async Task<CreateApplicationUserCommandResponse> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var department = mapper.Map<Department>(request.Department);

            IdentityResult result = await userManager.CreateAsync(new()
            {
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Department = department
            }, request.Password);

            CreateApplicationUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarıyla oluşturuldu.";
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }

            return response;
        }
    }
}
