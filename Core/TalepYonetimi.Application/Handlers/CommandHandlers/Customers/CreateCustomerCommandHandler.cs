using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.Commands.ApplicationUsers;
using TalepYonetimi.Application.Commands.Customers;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Customers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerWriteRepository customerWriteRepository;
        public CreateCustomerCommandHandler(ICustomerWriteRepository _customerWriteRepository)
        {
            customerWriteRepository = _customerWriteRepository;
        }
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await customerWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                Lastname = request.Lastname,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            });

            return await customerWriteRepository.SaveChangesAsync();
        }
    }
}
