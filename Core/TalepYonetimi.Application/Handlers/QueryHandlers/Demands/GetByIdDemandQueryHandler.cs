using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.Demands;

namespace TalepYonetimi.Application.Handlers.QueryHandlers.Demands
{
    public class GetByIdDemandQueryHandler : IRequestHandler<GetByIdDemandQuery, DemandDto>
    {
        private readonly IDemandReadRepository demandReadRepository;
        private readonly IMapper mapper;
        public GetByIdDemandQueryHandler(IDemandReadRepository _demandReadRepository, IMapper _mapper)
        {
            demandReadRepository = _demandReadRepository;
            mapper = _mapper;
        }
        public async Task<DemandDto> Handle(GetByIdDemandQuery request, CancellationToken cancellationToken)
        {
            var demand = await demandReadRepository.GetByIdAsync(request.Id);
            return mapper.Map<DemandDto>(demand);
        }
    }
}
