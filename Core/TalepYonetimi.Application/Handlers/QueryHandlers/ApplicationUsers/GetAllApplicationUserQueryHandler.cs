using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.ApplicationUsers;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.QueryHandlers.ApplicationUsers
{
    public class GetAllApplicationUserQueryHandler : IRequestHandler<GetAllApplicationUserQuery, IQueryable<ApplicationUserDto>>
    {
        private readonly IApplicationUserReadRepository applicationUserReadRepository;
        public GetAllApplicationUserQueryHandler(IApplicationUserReadRepository _applicationUserReadRepository)
        {
            applicationUserReadRepository = _applicationUserReadRepository;
        }
        public Task<IQueryable<ApplicationUserDto>> Handle(GetAllApplicationUserQuery request, CancellationToken cancellationToken)
        {
            var users = applicationUserReadRepository.GetAll(false).Select(u => new ApplicationUserDto
            {
                Name = u.Name,
                LastName = u.LastName,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Department = new DepartmentDto
                {
                    Id = u.Department.Id,
                    Name = u.Department.Name
                }
            });

            return Task.FromResult(users);
        }
    }
}
