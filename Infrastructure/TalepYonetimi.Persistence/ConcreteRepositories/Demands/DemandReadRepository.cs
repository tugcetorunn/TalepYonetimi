using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories.Demands
{
    public class DemandReadRepository : ReadRepository<Demand>, IDemandReadRepository
    {
        public DemandReadRepository(TalepYonetimiDbContext _context) : base(_context)
        {
        }
    }
}
