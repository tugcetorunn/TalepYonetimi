using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Domain.Entities.Admin
{
    public class ApplicationUser : IdentityUser
    {
        // identity 1. adım
        // user ve role işlemleri için identity ve identity.efCore kütüphanelerini yükledikten sonra appUser ve appRole classlarını oluşturup kalıtımlarını alıyoruz.
        // Identity kütüphanesinin barındırdığı property lere ek, tanımlamamız gereken property ler için oluşturdum.
        public string Name { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; } // userlar bizim çalışanlarımız oluyor, her çalışanın bir departmanı vardır.
    }
}
