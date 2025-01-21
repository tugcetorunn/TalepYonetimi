using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories.Demands
{
    public class DemandWriteRepository : WriteRepository<Demand>, IDemandWriteRepository
    {
        private readonly TalepYonetimiDbContext context;
        public DemandWriteRepository(TalepYonetimiDbContext _context) : base(_context)
        {
            context = _context;
        }

        public DbSet<Demand> Table => context.Set<Demand>();
        public Task<bool> DeleteDemandWithAuthorize(DemandDto demand)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDemandWithAutorize(DemandDto demand)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDepartmentInDemandAsync(DemandDto demand)
        {
            throw new NotImplementedException();
        }
    }
}
