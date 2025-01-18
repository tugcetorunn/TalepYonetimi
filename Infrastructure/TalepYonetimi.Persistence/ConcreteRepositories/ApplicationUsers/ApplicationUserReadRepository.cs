using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories.ApplicationUsers
{
    public class ApplicationUserReadRepository : ReadRepository<ApplicationUser>, IApplicationUserReadRepository
    {
        public ApplicationUserReadRepository(TalepYonetimiDbContext _context) : base(_context)
        {
        }
    }
}
