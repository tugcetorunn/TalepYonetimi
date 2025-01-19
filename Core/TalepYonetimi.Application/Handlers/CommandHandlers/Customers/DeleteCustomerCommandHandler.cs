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
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerReadRepository customerReadRepository;
        private readonly ICustomerWriteRepository customerWriteRepository;
        public DeleteCustomerCommandHandler(ICustomerWriteRepository _customerWriteRepository, ICustomerReadRepository _customerReadRepository)
        {
            customerWriteRepository = _customerWriteRepository;
            customerReadRepository = _customerReadRepository;
        }
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerReadRepository.GetByIdAsync(request.Id);

            if (customer != null)
            {
                await customerWriteRepository.RemoveAsync(customer);
                return await customerWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
