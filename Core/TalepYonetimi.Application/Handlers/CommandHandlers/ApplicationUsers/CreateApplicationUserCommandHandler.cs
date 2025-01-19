using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.Commands.ApplicationUsers;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.ApplicationUsers
{
    public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand, bool>
    {
        // mediatr-cqrs 2. adım
        // iş yapacak handler sınıflarını tanımlıyoruz. handler lar ırequesthandler interface inden miras alırken <request type, response type>
        // vermeli ve bu interface in handle metodunu implemente etmelidir.
        private readonly IApplicationUserWriteRepository applicationUserWriteRepository;
        private readonly IMapper mapper;
        public CreateApplicationUserCommandHandler(IApplicationUserWriteRepository _applicationUserWriteRepository, IMapper _mapper)
        {
            applicationUserWriteRepository = _applicationUserWriteRepository;
            mapper = _mapper;
        }
        public async Task<bool> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
        {
            DepartmentDto? departmentDto = request.Department ?? null;
            var department = mapper.Map<Department>(departmentDto);

            await applicationUserWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Department = department
            });

            return await applicationUserWriteRepository.SaveChangesAsync();

        }
    }
}
