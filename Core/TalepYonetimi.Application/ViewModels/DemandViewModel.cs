using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Application.ViewModels
{
    public class DemandViewModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public DemandType DemandType { get; set; }
        public string Message { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string CustomerName { get; set; }
        public string DepartmentName { get; set; }
    }
}
