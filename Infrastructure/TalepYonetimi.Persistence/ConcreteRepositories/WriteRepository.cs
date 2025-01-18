using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly TalepYonetimiDbContext context;
        public WriteRepository(TalepYonetimiDbContext _context)
        {
            context = _context;
        }
        public DbSet<T> Table => context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            EntityEntry<T> entityEntry = Table.Update(entity);

            await SaveChangesAsync();

            return entityEntry.State == EntityState.Modified;
        }
    }
}
