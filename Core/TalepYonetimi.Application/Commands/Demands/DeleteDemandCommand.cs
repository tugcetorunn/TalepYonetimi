using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.Commands.Demands
{
    public class DeleteDemandCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
