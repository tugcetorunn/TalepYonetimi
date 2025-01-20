using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;

namespace TalepYonetimi.Application.Queries.ApplicationUsers
{
    public class GetByIdApplicationUserQuery : IRequest<ApplicationUserDto>
    {
        public int Id { get; set; }
    }
}
