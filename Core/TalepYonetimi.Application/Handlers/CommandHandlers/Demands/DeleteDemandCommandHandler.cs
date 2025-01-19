using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Commands.Demands;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Demands
{
    public class DeleteDemandCommandHandler : IRequestHandler<DeleteDemandCommand, bool>
    {
        private readonly IDemandReadRepository demandReadRepository;
        private readonly IDemandWriteRepository demandWriteRepository;
        public DeleteDemandCommandHandler(IDemandReadRepository _demandReadRepository, IDemandWriteRepository _demandWriteRepository)
        {
            demandReadRepository = _demandReadRepository;
            demandWriteRepository = _demandWriteRepository;
        }
        public async Task<bool> Handle(DeleteDemandCommand request, CancellationToken cancellationToken)
        {
            var demand = await demandReadRepository.GetByIdAsync(request.Id);

            if (demand != null)
            {
                await demandWriteRepository.RemoveAsync(demand);
                return await demandWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
