using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Departments;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.Departments;

namespace TalepYonetimi.Application.Handlers.QueryHandlers.Departments
{
    public class GetByIdDepartmentQueryHandler : IRequestHandler<GetByIdDepartmentQuery, DepartmentDto>
    {
        private readonly IDepartmentReadRepository departmentReadRepository;
        private readonly IMapper mapper;
        public GetByIdDepartmentQueryHandler(IDepartmentReadRepository _departmentReadRepository, IMapper _mapper)
        {
            departmentReadRepository = _departmentReadRepository;
            mapper = _mapper;   
        }
        public async Task<DepartmentDto> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            var department = await departmentReadRepository.GetByIdAsync(request.Id);
            return mapper.Map<DepartmentDto>(department);
        }
    }
}
