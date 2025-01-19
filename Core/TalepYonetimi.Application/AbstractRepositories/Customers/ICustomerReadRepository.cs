using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.AbstractRepositories.Customers
{
    public interface ICustomerReadRepository : IReadRepository<Customer>
    {
        Task<CustomerDto> GetCustomerByPhoneNumberAsync(string phoneNumber, bool tracking = false);
    }
}
