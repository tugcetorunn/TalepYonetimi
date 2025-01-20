using AutoMapper;
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
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, CustomerDto>
    {
        private readonly ICustomerReadRepository customerReadRepository;
        private readonly IMapper mapper;
        public GetByIdCustomerQueryHandler(ICustomerReadRepository _customerReadRepository)
        {
            customerReadRepository = _customerReadRepository;
        }
        public async Task<CustomerDto> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await customerReadRepository.GetByIdAsync(request.Id);
            return mapper.Map<CustomerDto>(customer);
        }
    }
}
