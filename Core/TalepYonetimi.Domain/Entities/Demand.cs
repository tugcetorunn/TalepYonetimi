using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Domain.Entities
{
    public class Demand
    {
        public int DemandId { get; set; }
        public DemandType DemandType { get; set; } // talep türleri enum üzerinden çekilecek.
        public string Message { get; set; } // açıklama mesajı
        public DateTime ArrivalDate { get; set; } // talep geliş tarihi
        public DateTime CompletionDate { get; set; } // talep tamamlanma tarihi
        //public int CustomerId { get; set; }
        public Customer Customer { get; set; } // bir talebin bir müşterisi olur.
        //public int DepartmentId { get; set; }
        public Department Department { get; set; } // bir talep bir departmanla ilgilidir.
    }
}
