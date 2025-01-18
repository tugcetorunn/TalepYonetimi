using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.AbstractRepositories;
using TalepYonetimi.Persistence.Contexts;

namespace TalepYonetimi.Persistence.ConcreteRepositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly TalepYonetimiDbContext context;
        public ReadRepository(TalepYonetimiDbContext _context)
        {
            context = _context;
        }
        
        // context.Set<TEntity>() mouse la üstüne geldiğmizde DbSet<TEntity> ye karşılık geldiğini görüyoruz.
        public DbSet<T> Table => context.Set<T>(); // context.Set<TEntity>() --> DbSet<Customer>, DbSet<Demand>... dbsetten dönüştürerek genelden özele entity lere ulaşmış oluyoruz.

        public IQueryable<T> GetAll(bool tracking = true)
        {
            IQueryable<T> query = Table.AsQueryable(); // asNoTracking metodu ıqueryable tipli değişkenle çalıştığı için table nesnemizi iqueryable tipe dönüştürüyoruz.
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => EF.Property<int>(entity, "Id") == id); // primary key üzerinden sorgu yaparak bulur.
        }
    }
}
