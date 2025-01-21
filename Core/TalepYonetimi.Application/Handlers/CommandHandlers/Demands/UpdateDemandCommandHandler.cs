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
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.CommandHandlers.Demands
{
    public class UpdateDemandCommandHandler : IRequestHandler<UpdateDemandCommand, bool>
    {
        private readonly IDemandReadRepository demandReadRepository;
        private readonly IDemandWriteRepository demandWriteRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        public UpdateDemandCommandHandler(IDemandReadRepository _demandReadRepository, IDemandWriteRepository _demandWriteRepository, IMapper _mapper, UserManager<ApplicationUser> _userManager)
        {
            demandReadRepository = _demandReadRepository;
            demandWriteRepository = _demandWriteRepository;
            mapper = _mapper;
            userManager = _userManager;
        }
        public async Task<bool> Handle(UpdateDemandCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (user == null)
            {
                return false;
            }

            var departmentId = user.Department.Id;

            var demand = await demandReadRepository.GetByIdAsync(request.DemandId);
            var customer = mapper.Map<Customer>(request.Customer);
            var department = mapper.Map<Department>(request.Department);

            if (demand != null && demand.Department.Id == departmentId)
            {
                demand.DemandType = request.DemandType;
                demand.Message = request.Message;
                demand.Product = request.Product;
                demand.ArrivalDate = request.ArrivalDate;
                demand.CompletionDate = request.CompletionDate;
                demand.Customer = customer;
                demand.Department = department;

                return await demandWriteRepository.SaveChangesAsync();
            }

            return false;
        }
    }
}
