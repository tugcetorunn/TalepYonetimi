using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.Commands.ApplicationUsers
{
    public class UpdateApplicationUserCommand : IRequest<bool>
    {
        public string Id { get; set; } // hangi user ın update edileceği id bilgisi ile geleceği için id yi parametre olarak veriyoruz.
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DepartmentDto? Department { get; set; }
    }
}
