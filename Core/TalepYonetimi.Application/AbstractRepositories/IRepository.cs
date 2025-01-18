using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.AbstractRepositories
{
    public interface IRepository<T> where T : class // generic repository interface ile ortak metodları yazıyoruz. entity lere özel metodlar için
                                                    // kendi repository interface lerinde tanımlanabilir.
    {
        // DbSet<T> her metotta tekrar ettiği için bunu bir değişken haline getirelim.
        DbSet<T> Table { get; } // hangi entity olursa olsun içindeki property leri getirecek.
    }
}
