using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.AbstractRepositories.ApplicationUsers
{
    public interface IApplicationUserReadRepository : IReadRepository<ApplicationUser>
    {
        Task<List<ApplicationUserDto>> GetAllUsersAsync(bool tracking = true); 
        Task<ApplicationUserDto> GetByIdUserAsync(string id, bool tracking = true); // identityUser da id ler default olarak string olduğu için yazdım.
    }
}
