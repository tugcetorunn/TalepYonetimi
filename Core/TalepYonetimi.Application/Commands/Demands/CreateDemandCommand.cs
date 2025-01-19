using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Application.Commands.Demands
{
    public class CreateDemandCommand : IRequest<bool>
    {
        public DemandType DemandType { get; set; } 
        public Product Product { get; set; } 
        public string? Message { get; set; } 
        public CustomerDto? Customer { get; set; } 
        public DepartmentDto? Department { get; set; }
    }
}
