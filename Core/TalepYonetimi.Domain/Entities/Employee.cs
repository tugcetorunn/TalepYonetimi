using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Domain.Entities
{
    public class Employee : BasePerson
    {
        public int EmployeeId { get; set; }
        //public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
