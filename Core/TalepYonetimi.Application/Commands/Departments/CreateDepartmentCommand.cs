using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Application.Commands.Departments
{
    public class CreateDepartmentCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
