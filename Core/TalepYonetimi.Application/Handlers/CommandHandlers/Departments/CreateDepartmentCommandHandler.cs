using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Departments;
using TalepYonetimi.Application.Commands.Departments;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Departments
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
    {
        private readonly IDepartmentWriteRepository departmentWriteRepository;
        public CreateDepartmentCommandHandler(IDepartmentWriteRepository _departmentWriteRepository)
        {
            departmentWriteRepository = _departmentWriteRepository;
        }
        public async Task<bool> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            await departmentWriteRepository.AddAsync(new()
            {
                Name = request.Name
            });

            return await departmentWriteRepository.SaveChangesAsync();
        }
    }
}
