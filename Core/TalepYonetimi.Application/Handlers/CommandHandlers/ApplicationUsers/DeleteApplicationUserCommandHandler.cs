using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.Commands.ApplicationUsers;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.ApplicationUsers
{
    public class DeleteApplicationUserCommandHandler : IRequestHandler<DeleteApplicationUserCommand, bool>
    {
        private readonly IApplicationUserWriteRepository applicationUserWriteRepository;
        private readonly IApplicationUserReadRepository applicationUserReadRepository;
        private readonly IMapper mapper;
        public DeleteApplicationUserCommandHandler(IApplicationUserWriteRepository _applicationUserWriteRepository, IApplicationUserReadRepository _applicationUserReadRepository, IMapper _mapper)
        {
            applicationUserWriteRepository = _applicationUserWriteRepository;
            applicationUserReadRepository = _applicationUserReadRepository;
            mapper = _mapper;
        }
        public async Task<bool> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = await applicationUserReadRepository.GetByIdUserAsync(request.Id); // tracking default değeri olan true da kalacak. çünkü delete işlemi yapıyoruz.
            var user = mapper.Map<ApplicationUser>(userDto);

            if (user != null)
            {
                await applicationUserWriteRepository.RemoveAsync(user);
                return await applicationUserWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
