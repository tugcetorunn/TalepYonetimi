using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;

namespace TalepYonetimi.Application.Queries.Demands
{
    public class GetAllDemandWithAuthorizeQuery : IRequest<IQueryable<DemandDto>>
    {
        public int UserId { get; set; }
    }
}
