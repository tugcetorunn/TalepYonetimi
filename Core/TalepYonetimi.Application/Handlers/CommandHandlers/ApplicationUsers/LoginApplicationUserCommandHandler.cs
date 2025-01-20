using MediatR;
using Microsoft.AspNetCore.Identity;
using TalepYonetimi.Application.Commands.ApplicationUsers;
using TalepYonetimi.Application.Exceptions;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.ApplicationUsers
{
    public class LoginApplicationUserCommandHandler : IRequestHandler<LoginApplicationUserCommand, LoginApplicationUserCommandResponse>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager; // kullanıcı giriş işlemleriyle ilgili metodlar barındıran identity manager

        public LoginApplicationUserCommandHandler(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<LoginApplicationUserCommandResponse> Handle(LoginApplicationUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new NotFoundApplicationUserException();
            }

            SignInResult result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            LoginApplicationUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı girişi başarıyla yapıldı."; // yetkiler belirlenecek.
            }
            else
            {
                response.Message = "Kullanıcı girişi hatalı!";
            }

            return response;
        }
    }
}
