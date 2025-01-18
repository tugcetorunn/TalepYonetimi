using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Domain.Entities;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Application.Dtos
{
    public class DemandDto
    {
        public int Id { get; set; }
        public DemandType DemandType { get; set; } // talep türleri enum üzerinden çekilecek.
        public string Message { get; set; } // açıklama mesajı
        public DateTime ArrivalDate { get; set; } // talep geliş tarihi
        public DateTime CompletionDate { get; set; } // talep tamamlanma tarihi
        public CustomerDto Customer { get; set; } // bir talebin bir müşterisi olur.
        public DepartmentDto Department { get; set; }
    }
}
