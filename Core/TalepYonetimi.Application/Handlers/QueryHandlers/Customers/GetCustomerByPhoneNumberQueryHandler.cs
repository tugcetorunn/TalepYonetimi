using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.Customers;

namespace TalepYonetimi.Application.Handlers.QueryHandlers.Customers
{
    public class GetCustomerByPhoneNumberQueryHandler : IRequestHandler<GetCustomerByPhoneNumberQuery, CustomerDto>
    {
        private readonly ICustomerReadRepository customerReadRepository;
        public GetCustomerByPhoneNumberQueryHandler(ICustomerReadRepository _customerReadRepository)
        {
            customerReadRepository = _customerReadRepository;
        }
        public async Task<CustomerDto> Handle(GetCustomerByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            return await customerReadRepository.GetCustomerByPhoneNumberAsync(request.PhoneNumber);
        }
    }
}
