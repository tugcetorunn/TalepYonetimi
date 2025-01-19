using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;

namespace TalepYonetimi.Application.Queries.Customers
{
    public class GetCustomerByPhoneNumberQuery : IRequest<CustomerDto>
    {
        public string PhoneNumber { get; set; } // controller da demand create edilirken CreateDemandCommand new lendiği kısımda customer bilgi girmemiz
                                                // gerekiyor. new leyerek customer propertylerini giremeyiz db de iki kez oluşturmuş oluyoruz. bu yüzden
                                                // hem önce db mizde bu phoneNumber a sahip customer var mı diye kontrol ediyoruz hem de iki kez create
                                                // edilmesini önlüyoruz. phoneNumber customer için belirleyici faktör olmuş oldu.
    }
}
