using AutoMapper;
using MediatR;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.Commands.Customers;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Customers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        // mediatr-cqrs 2. adım
        // iş yapacak handler sınıflarını tanımlıyoruz. handler lar ırequesthandler interface inden miras alırken <request type, response type>
        // vermeli ve bu interface in handle metodunu implemente etmelidir.
        private readonly ICustomerWriteRepository customerWriteRepository;
        private readonly IMapper mapper;
        public CreateCustomerCommandHandler(ICustomerWriteRepository _customerWriteRepository, IMapper _mapper)
        {
            customerWriteRepository = _customerWriteRepository;
            mapper = _mapper;
        }
        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerDto = mapper.Map<CustomerDto>(request);
            var customer = mapper.Map<Customer>(customerDto);

            await customerWriteRepository.AddAsync(customer);

            await customerWriteRepository.SaveChangesAsync();

            return mapper.Map<CustomerDto>(customer); // oluşturulan nesnenin id bilgisini almak için. (demandcontroller)
        }
    }
}
