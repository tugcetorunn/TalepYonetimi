using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories.ApplicationUsers;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories.ApplicationUsers
{
    public class ApplicationUserReadRepository : ReadRepository<ApplicationUser>, IApplicationUserReadRepository
    {
        private readonly TalepYonetimiDbContext context;
        private readonly IMapper mapper;
        public ApplicationUserReadRepository(TalepYonetimiDbContext _context, IMapper _mapper) : base(_context)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task<ApplicationUserDto> GetByIdUserAsync(string id, bool tracking = true)
        {
            var query = context.Set<ApplicationUser>().AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            var result = await query.FirstOrDefaultAsync(entity => EF.Property<string>(entity, "Id") == id);
            return mapper.Map<ApplicationUserDto>(result);
        }

        public async Task<List<ApplicationUserDto>> GetAllUsersAsync(bool tracking)
        {
            var query = context.Set<ApplicationUser>().AsQueryable(); 
            if (!tracking)
                query = query.AsNoTracking();

            var users = await query.ToListAsync();
            return mapper.Map<List<ApplicationUserDto>>(users);
        }
    }
}
