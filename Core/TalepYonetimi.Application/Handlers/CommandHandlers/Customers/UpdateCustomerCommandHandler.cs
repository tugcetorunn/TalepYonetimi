using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.Commands.Customers;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Customers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerReadRepository customerReadRepository;
        private readonly ICustomerWriteRepository customerWriteRepository;
        public UpdateCustomerCommandHandler(ICustomerWriteRepository _customerWriteRepository, ICustomerReadRepository _customerReadRepository)
        {
            customerWriteRepository = _customerWriteRepository;
            customerReadRepository = _customerReadRepository;
        }
        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerReadRepository.GetByIdAsync(request.Id);

            if (customer != null)
            {
                customer.Name = request.Name;
                customer.Lastname = request.Lastname;
                customer.Email = request.Email;
                customer.PhoneNumber = request.PhoneNumber;

                return await customerWriteRepository.SaveChangesAsync();
            }
            
            return false;
        }
    }
}
