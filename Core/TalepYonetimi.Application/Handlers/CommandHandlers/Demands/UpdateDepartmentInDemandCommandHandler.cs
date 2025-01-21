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
    public class UpdateDepartmentInDemandCommandHandler : IRequestHandler<UpdateDepartmentInDemandCommand, bool>
    {
        private readonly IDemandReadRepository demandReadRepository;
        private readonly IDemandWriteRepository demandWriteRepository;

        public UpdateDepartmentInDemandCommandHandler(IDemandReadRepository _demandReadRepository, IDemandWriteRepository _demandWriteRepository)
        {
            demandReadRepository = _demandReadRepository;
            demandWriteRepository = _demandWriteRepository;
        }

        public async Task<bool> Handle(UpdateDepartmentInDemandCommand request, CancellationToken cancellationToken)
        {
            var demand = demandReadRepository.GetByIdWithIncludes(request.Id);

            demand.DepartmentId = request.DepartmentId;

            await demandWriteRepository.SaveChangesAsync();

            return true;
        }
    }
}
