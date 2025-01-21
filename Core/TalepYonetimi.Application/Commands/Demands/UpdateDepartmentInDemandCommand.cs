using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.Commands.Demands
{
    public class UpdateDepartmentInDemandCommand : IRequest<bool>
    {
        public int Id { get; set; } // seçili talep için id
        public int DepartmentId { get; set; } // talebe eklenecek departman
    }
}
