using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Customers;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Commands.Demands;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Demands
{
    public class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, bool>
    {
        private readonly IDemandWriteRepository demandWriteRepository;
        private readonly ICustomerReadRepository customerReadRepository;
        public CreateDemandCommandHandler(IDemandWriteRepository _demandWriteRepository, ICustomerReadRepository _customerReadRepository)
        {
            demandWriteRepository = _demandWriteRepository;
            customerReadRepository = _customerReadRepository;
        }
        public async Task<bool> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerReadRepository.GetByIdAsync(request.CustomerId);

            await demandWriteRepository.AddAsync(new()
            {
                DemandType = request.DemandType,
                Product = request.Product,
                Customer = customer,
                Message = request.Message
            });

            return await demandWriteRepository.SaveChangesAsync();
        }
    }
}
