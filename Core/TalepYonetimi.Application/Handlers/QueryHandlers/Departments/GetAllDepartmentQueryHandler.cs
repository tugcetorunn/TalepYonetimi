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
    public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, IQueryable<DepartmentDto>>
    {
        private readonly IDepartmentReadRepository departmentReadRepository;
        public GetAllDepartmentQueryHandler(IDepartmentReadRepository _departmentReadRepository)
        {
            departmentReadRepository = _departmentReadRepository;
        }
        public Task<IQueryable<DepartmentDto>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departments = departmentReadRepository.GetAll(false).Select(d => new DepartmentDto
            {
                Name = d.Name
            });

            return Task.FromResult(departments);
        }
    }
}
