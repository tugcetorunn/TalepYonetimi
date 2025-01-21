using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.AbstractRepositories.Demands
{
    public interface IDemandReadRepository : IReadRepository<Demand>
    {
        IQueryable<DemandDto> GetAllWithIncludes(bool tracking = true);
        DemandDto GetByIdWithIncludes(int id, bool tracking = true);

    }
}
