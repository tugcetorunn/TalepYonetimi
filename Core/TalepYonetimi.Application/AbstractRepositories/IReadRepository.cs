using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.AbstractRepositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool tracking = true); // metoda göre tracking mekanizması çalıştırılacaksa true default ayarlandı. gerek duyulmazsa false işaretlenip tracking i meşgul etmeden metod çalıştırılır.
        Task<T> GetByIdAsync(int id, bool tracking = true);
    }
}
