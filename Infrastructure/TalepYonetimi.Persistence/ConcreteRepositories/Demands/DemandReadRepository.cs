using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Domain.Enums;
using TalepYonetimi.Persistence.Contexts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TalepYonetimi.Persistence.ConcreteRepositories.Demands
{
    public class DemandReadRepository : ReadRepository<Demand>, IDemandReadRepository
    {
        private readonly TalepYonetimiDbContext context;
        public DemandReadRepository(TalepYonetimiDbContext _context) : base(_context)
        {
            context = _context;
        }

        public DbSet<Demand> Table => context.Set<Demand>();

        public IQueryable<DemandDto> GetAllWithIncludes(bool tracking = true)
        {
            //var products = System.Enum.GetValues(typeof(Product));
            var demands = Table.Include(d => d.Customer)
                                               .Include(d => d.Department).Select(d => new DemandDto
                                               {
                                                   Id = d.Id,
                                                   DemandType = d.DemandType,
                                                   CustomerName = d.Customer.Name + " " + d.Customer.Lastname,
                                                   DepartmentName = d.Department.Name,
                                                   Product =d.Product,
                                                   ArrivalDate = d.ArrivalDate,
                                                   CompletionDate = d.CompletionDate ?? default(DateTime),
                                                   Message = d.Message
                                               });

            return tracking ? demands : demands.AsNoTracking();
        }

        public DemandDto GetByIdWithIncludes(int id, bool tracking = true)
        {
            var demand = Table.Include(d => d.Customer)
                              .Include(d => d.Department).Select(d => new DemandDto
                               {
                                   Id = d.Id,
                                   DemandType = d.DemandType,
                                   CustomerName = d.Customer.Name + " " + d.Customer.Lastname,
                                   DepartmentName = d.Department.Name,
                                   Product = d.Product,
                                   ArrivalDate = d.ArrivalDate,
                                   CompletionDate = d.CompletionDate ?? default(DateTime),
                                   Message = d.Message
                               });

            return tracking ? demand.FirstOrDefault(d => d.Id == id) : demand.AsNoTracking().FirstOrDefault(d => d.Id == id);
        }
    }
}
