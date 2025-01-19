using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Departments;
using TalepYonetimi.Application.Commands.Demands;
using TalepYonetimi.Application.Commands.Departments;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Departments
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, bool>
    {
        private readonly IDepartmentReadRepository departmentReadRepository;
        private readonly IDepartmentWriteRepository departmentWriteRepository;
        public UpdateDepartmentCommandHandler(IDepartmentReadRepository _departmentReadRepository, IDepartmentWriteRepository _departmentWriteRepository)
        {
            departmentReadRepository = _departmentReadRepository;
            departmentWriteRepository = _departmentWriteRepository;
        }
        public async Task<bool> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await departmentReadRepository.GetByIdAsync(request.Id);

            if (department != null)
            {
                department.Name = request.Name;

                return await departmentWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
