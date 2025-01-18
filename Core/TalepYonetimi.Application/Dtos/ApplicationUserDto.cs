using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.Dtos
{
    public class ApplicationUserDto
    {
        // Automapper 1. adım Automapper ve AutoMapper.Extensions.Microsoft.DependencyInjection paketlerinin aynı versiyonlarla yüklenmesi
        // Automapper 2. adım Dto ların oluşturulması
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
    }
}
