using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.Demands;
using TalepYonetimi.Application.Commands.Demands;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Demands
{
    public class DeleteDemandCommandHandler : IRequestHandler<DeleteDemandCommand, bool>
    {
        private readonly IDemandReadRepository demandReadRepository;
        private readonly IDemandWriteRepository demandWriteRepository;
        private readonly UserManager<ApplicationUser> userManager; 
        public DeleteDemandCommandHandler(IDemandReadRepository _demandReadRepository, IDemandWriteRepository _demandWriteRepository, UserManager<ApplicationUser> _userManager)
        {
            demandReadRepository = _demandReadRepository;
            demandWriteRepository = _demandWriteRepository;
            userManager = _userManager;
        }
        public async Task<bool> Handle(DeleteDemandCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (user == null)
            {
                return false;
            }

            var departmentId = user.Department.Id;

            var demand = await demandReadRepository.GetByIdAsync(request.DemandId);

            if (demand != null && demand.Department.Id == departmentId)
            {
                await demandWriteRepository.RemoveAsync(demand);
                return await demandWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
