using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Commands.Demands;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Demands
{
    public class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, bool>
    {
        private readonly IDemandWriteRepository demandWriteRepository;
        private readonly IMapper mapper;
        public CreateDemandCommandHandler(IDemandWriteRepository _demandWriteRepository, IMapper _mapper)
        {
            demandWriteRepository = _demandWriteRepository;
            mapper = _mapper;
        }
        public async Task<bool> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Customer>(request.Customer);

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
