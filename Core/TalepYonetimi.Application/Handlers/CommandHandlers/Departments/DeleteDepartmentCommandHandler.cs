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
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartmentReadRepository departmentReadRepository;
        private readonly IDepartmentWriteRepository departmentWriteRepository;

        public DeleteDepartmentCommandHandler(IDepartmentReadRepository _departmentReadRepository, IDepartmentWriteRepository _departmentWriteRepository)
        {
            departmentReadRepository = _departmentReadRepository;
            departmentWriteRepository = _departmentWriteRepository;
        }

        public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = await departmentReadRepository.GetByIdAsync(request.Id);

            if (department != null)
            {
                await departmentWriteRepository.RemoveAsync(department);
                return await departmentWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
