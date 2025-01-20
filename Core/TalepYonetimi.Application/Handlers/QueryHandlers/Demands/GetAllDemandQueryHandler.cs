using AutoMapper;
using MediatR;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.Demands;

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
            var demands = demandReadRepository.GetAll(false).Select(d => new DemandDto
            {
                DemandType = d.DemandType,
                ArrivalDate = d.ArrivalDate,
                CompletionDate = (DateTime)d.CompletionDate,
                Message = d.Message,
                CustomerId = d.Customer.Id,
                DepartmentId = d.Department.Id
            });

            return Task.FromResult(demands);
        }
    }
}
