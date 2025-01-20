using MediatR;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.Customers;

namespace TalepYonetimi.Application.Handlers.QueryHandlers.Customers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IQueryable<CustomerDto>>
    {
        private readonly ICustomerReadRepository customerReadRepository;
        public GetAllCustomerQueryHandler(ICustomerReadRepository _customerReadRepository)
        {
            customerReadRepository = _customerReadRepository;
        }
        public Task<IQueryable<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = customerReadRepository.GetAll(false).Select(c => new CustomerDto // customerDto dönüşünü sağlamış oluyoruz ve hangi propertylerin döneceğini belirliyoruz.
            {
                Name = c.Name,
                Lastname = c.Lastname,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber
            });

            return Task.FromResult(customers);
        }
    }
}
