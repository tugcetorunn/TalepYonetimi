using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.Commands.ApplicationUsers
{
    public class DeleteApplicationUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
