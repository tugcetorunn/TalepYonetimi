using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.Commands.ApplicationUsers;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.ApplicationUsers
{
    public class UpdateApplicationUserCommandHandler : IRequestHandler<UpdateApplicationUserCommand, bool>
    {
        private readonly IApplicationUserWriteRepository applicationUserWriteRepository;
        private readonly IApplicationUserReadRepository applicationUserReadRepository;
        private readonly IMapper mapper;
        public UpdateApplicationUserCommandHandler(IApplicationUserWriteRepository _applicationUserWriteRepository, IApplicationUserReadRepository _applicationUserReadRepository, IMapper _mapper)
        {
            applicationUserWriteRepository = _applicationUserWriteRepository;
            applicationUserReadRepository = _applicationUserReadRepository;
            mapper = _mapper;
        }
        public async Task<bool> Handle(UpdateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            var userDto = await applicationUserReadRepository.GetByIdUserAsync(request.Id); // tracking default değeri olan true da kalacak. çünkü güncelleme işlemi yapıyoruz.
            var user = mapper.Map<ApplicationUser>(userDto);

            var department = mapper.Map<Department>(request.Department);

            if (user != null)
            {

                user.Name = request.Name;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;
                user.Department = department;

                return await applicationUserWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
