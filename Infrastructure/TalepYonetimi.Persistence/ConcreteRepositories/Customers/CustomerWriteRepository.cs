using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories.Customers
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(TalepYonetimiDbContext _context) : base(_context)
        {
        }
    }
}
