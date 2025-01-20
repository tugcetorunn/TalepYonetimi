using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TalepYonetimi.Application.Exceptions
{
    public class NotFoundApplicationUserException : Exception
    {
        public NotFoundApplicationUserException() : base("Kullanıcı adı veya şifre hatalı!")
        {
        }

        public NotFoundApplicationUserException(string? message) : base(message)
        {
        }

        public NotFoundApplicationUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
