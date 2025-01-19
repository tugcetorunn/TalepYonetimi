using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ApplicationUser>? ApplicationUsers { get; set; } // departman-çalışan bire çok ilişki
        public ICollection<Demand>? Demands { get; set; } // departman-müşteri talebi bire çok ilişki
    }
}
