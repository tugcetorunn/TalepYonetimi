using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Domain.Entities.Admin;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ApplicationUserDto> ApplicationUsers { get; set; }
        public ICollection<DemandDto> Demands { get; set; }
    }
}
