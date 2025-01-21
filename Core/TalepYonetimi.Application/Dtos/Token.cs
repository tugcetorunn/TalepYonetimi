using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.Dtos
{
    public class Token
    {
        public string JWTToken { get; set; } // token
        public DateTime Expiration { get; set; } // token ömrü
    }
}
