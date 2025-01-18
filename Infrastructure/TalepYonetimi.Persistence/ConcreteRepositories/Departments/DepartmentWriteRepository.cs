using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.AbstractRepositories.Departments;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories.Departments
{
    public class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(TalepYonetimiDbContext _context) : base(_context)
        {
        }
    }
}
