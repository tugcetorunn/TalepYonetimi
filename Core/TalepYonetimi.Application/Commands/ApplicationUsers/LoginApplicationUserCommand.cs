using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.Commands.ApplicationUsers
{
    public class LoginApplicationUserCommand : IRequest<LoginApplicationUserCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
