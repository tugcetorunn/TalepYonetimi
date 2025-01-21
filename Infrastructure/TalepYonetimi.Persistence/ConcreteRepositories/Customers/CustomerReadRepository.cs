using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories.Customers
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        private readonly TalepYonetimiDbContext context;
        private readonly IMapper mapper;
        public CustomerReadRepository(TalepYonetimiDbContext _context, IMapper _mapper) : base(_context)
        {
            context = _context;
            mapper = _mapper;
        }

        public DbSet<Customer> Table => context.Set<Customer>();
        public async Task<CustomerDto> GetCustomerByPhoneNumberAsync(string phoneNumber, bool tracking = false)
        {
            IQueryable<Customer> query = Table;
            if (!tracking)
            {
                query = query.AsNoTracking(); // demand e customer entegre edilirken yeniden customer oluştuğu için burada da özellikle tracking i kapatıyoruz.
            }
            var customer = await query.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
            return mapper.Map<CustomerDto>(customer);
        }
    }
}
