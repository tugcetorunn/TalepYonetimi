using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.ApplicationUsers;

namespace TalepYonetimi.Application.Handlers.QueryHandlers.ApplicationUsers
{
    public class GetByIdApplicationUserQueryHandler : IRequestHandler<GetByIdApplicationUserQuery, ApplicationUserDto>
    {
        private readonly IApplicationUserReadRepository applicationUserReadRepository;
        public GetByIdApplicationUserQueryHandler(IApplicationUserReadRepository _applicationUserReadRepository)
        {
            applicationUserReadRepository = _applicationUserReadRepository;
        }
        public async Task<ApplicationUserDto> Handle(GetByIdApplicationUserQuery request, CancellationToken cancellationToken)
        {
            return await applicationUserReadRepository.GetByIdUserAsync(request.Id, false);
             
        }
    }
}
