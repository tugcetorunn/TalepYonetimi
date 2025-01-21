using AutoMapper;
using MediatR;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.Demands;
using TalepYonetimi.Application.ViewModels;

namespace TalepYonetimi.Application.Handlers.QueryHandlers.Demands
{
    public class GetAllDemandQueryHandler : IRequestHandler<GetAllDemandQuery, IQueryable<DemandDto>>
    {
        private readonly IDemandReadRepository demandReadRepository;
        private readonly IMapper mapper;
        public GetAllDemandQueryHandler(IDemandReadRepository _demandReadRepository, IMapper _mapper)
        {
            demandReadRepository = _demandReadRepository;
            mapper = _mapper;
        }
        public Task<IQueryable<DemandDto>> Handle(GetAllDemandQuery request, CancellationToken cancellationToken)
        {
            var demands = demandReadRepository.GetAllWithIncludes(false);

            return Task.FromResult(demands);
        }
    }
}
