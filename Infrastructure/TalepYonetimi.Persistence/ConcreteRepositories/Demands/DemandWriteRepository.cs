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
    public class DemandWriteRepository : WriteRepository<Demand>, IDemandWriteRepository
    {
        public DemandWriteRepository(TalepYonetimiDbContext _context) : base(_context)
        {
        }
    }
}
