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
    public class ApplicationUserWriteRepository : WriteRepository<ApplicationUser>, IApplicationUserWriteRepository
    {
        // readRepository implemente edilerek genel yazılan metodları barındırmış oluyor, IApplicationUserReadRepository implemente ederek
        // bu class a özel yazılmış metod varsa onları implemente etmiş oluyor.
        public ApplicationUserWriteRepository(TalepYonetimiDbContext _context) : base(_context)
        {
            // base class a yani ReadRepository<T> ye ioc üzerinden dependency injection için gereken context nesnesini gönderiyor.
        }
    }
}
