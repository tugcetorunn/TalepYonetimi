using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;

namespace TalepYonetimi.Application.Commands.Customers
{
    public class CreateCustomerCommand : IRequest<CustomerDto>
    {
        // CQRS --> db de manipülasyon yapıp yapmamasına göre service leri (metodları) command(create, update, delete) veya query(read) olarak
        // ayırırız. daha çok get istekleri yapıldığı için projede get leri ayrı diğerlerini ayrı yerde tutarak performansı güçlendirmiş oluruz.

        // mediatr-cqrs 1. adım
        // önce projeye beraber çalıştığı mediatr eklentisini yükleriz. command ve query ler oluşturulurken ırequest ten miras alır dönüş tipi
        // olarak içerisine response type yazılır. bu metod çalıştırıldıktan sonra geriye response olarak true veya false dönecek.
        // command ve queryler kullanıcıdan gelen isteklerdir ve bu istekleri tutarken parametrelerini de alıp işleyecek handler lara gönderir.

        // hangi command ya da query nin hangi ilgili handler a gönderileceği görevini mediatr üstlenir.

        // abstraction önemli entity leri direk kullanmıyoruz dto lardan faydalanıyoruz.

        // onion architecture da command, query, handlerlar entity lerin işlendiği soyut sınıflarının olduğu application katmanında yazılır. normalde
        // burada interface ler bulunurken neden handler ları business işlemi yapıyorken buraya yazıyoruz? çünkü bu handler lar da direk business işlemi
        // değil persistence da tanımlanan repository concrete lerini kullanacak.

        // ioc sayesinde üst katmandan(persistence) alt katmandaki(application) bir handler erişim sağlıyor olacak.

        // bu command ve query ler içerisinde CreateCustomer metodu uygulanırken kullanıcıdan gelecek parametreler yazılır.

        // id ef core tarafından otomatik oluşturulduğu için yazmıyoruz.
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
