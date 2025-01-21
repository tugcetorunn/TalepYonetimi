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
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.Demands;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.Handlers.QueryHandlers.Demands
{
    public class GetAllDemandWithAuthorizeQueryHandler : IRequestHandler<GetAllDemandWithAuthorizeQuery, IQueryable<DemandDto>>
    {
        private readonly IDemandReadRepository demandReadRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public GetAllDemandWithAuthorizeQueryHandler(IDemandReadRepository _demandReadRepository, UserManager<ApplicationUser> _userManager)
        {
            demandReadRepository = _demandReadRepository;
            userManager = _userManager;
        }

        public async Task<IQueryable<DemandDto>> Handle(GetAllDemandWithAuthorizeQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

            if (user == null)
            {
                return null;
            }

            var departmentId = user.Department.Id;

            var demands = demandReadRepository.GetAllWithIncludes(false).Where(d => d.DepartmentId == departmentId);

            return demands;
        }
    }
}
