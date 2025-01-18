using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.AbstractRepositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
