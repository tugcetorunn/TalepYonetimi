using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.ViewModels;

namespace TalepYonetimi.Application.Queries.Demands
{
    public class GetAllDemandQuery : IRequest<IQueryable<DemandDto>>
    {
        // yönetici tüm talepleri görebilecek.
    }
}
