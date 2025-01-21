using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;

namespace TalepYonetimi.Application.Abstractions
{
    public interface ITokenHandler
    {
        Task<Token> CreateJWTToken(int hours, string email, int userId);
    }
}
