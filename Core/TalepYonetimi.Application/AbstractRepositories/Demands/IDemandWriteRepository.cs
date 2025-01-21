using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.AbstractRepositories.Demands
{
    public interface IDemandWriteRepository : IWriteRepository<Demand>
    {
        Task<bool> UpdateDepartmentInDemandAsync(DemandDto demand); // yönetici talepleri departmanlara atayacak.
        Task<bool> UpdateDemandWithAutorize(DemandDto demand); // kullanıcılar sadece kendi departmanına gelen talepleri düzenleyebilirler.
        Task<bool> DeleteDemandWithAuthorize(DemandDto demand); // kullanıcılar sadece kendi departmanına gelen talepleri silebilirler.
    }
}
