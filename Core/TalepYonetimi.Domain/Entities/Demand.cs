using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Domain.Entities
{
    public class Demand
    {
        public int Id { get; set; }
        public DemandType DemandType { get; set; } // talep türleri enum üzerinden çekilecek.
        public Product Product { get; set; } // ürünler enum üzerinden çekilecek.
        public string? Message { get; set; } // açıklama mesajı
        public DateTime ArrivalDate { get; set; } = DateTime.Now; // talep geliş tarihi
        public DateTime? CompletionDate { get; set; } // talep tamamlanma tarihi // talep düştüğü anda bu kısımlar boş olacağından nullable olması gerek.
        public Customer? Customer { get; set; } // bir talebin bir müşterisi olur. // talep düştüğü anda bu kısımlar boş olacağından nullable olması gerek.
        public Department? Department { get; set; } // bir talep bir departmanla ilgilidir. // talep düştüğü anda bu kısımlar boş olacağından nullable olması gerek.
    }
}
