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
    public class UpdateDemandCommandHandler : IRequestHandler<UpdateDemandCommand, bool>
    {
        private readonly IDemandReadRepository demandReadRepository;
        private readonly IDemandWriteRepository demandWriteRepository;
        private readonly IMapper mapper;
        public UpdateDemandCommandHandler(IDemandReadRepository _demandReadRepository, IDemandWriteRepository _demandWriteRepository, IMapper _mapper)
        {
            demandReadRepository = _demandReadRepository;
            demandWriteRepository = _demandWriteRepository;
            mapper = _mapper;
        }
        public async Task<bool> Handle(UpdateDemandCommand request, CancellationToken cancellationToken)
        {
            var demand = await demandReadRepository.GetByIdAsync(request.Id);
            var customer = mapper.Map<Customer>(request.Customer);
            var department = mapper.Map<Department>(request.Department);

            if (demand != null)
            {
                demand.DemandType = request.DemandType;
                demand.Message = request.Message;
                demand.Product = request.Product;
                demand.ArrivalDate = request.ArrivalDate;
                demand.CompletionDate = request.CompletionDate;
                demand.Customer = customer;
                demand.Department = department;

                return await demandWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
