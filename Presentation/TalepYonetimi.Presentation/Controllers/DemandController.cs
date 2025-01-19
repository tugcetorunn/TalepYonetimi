using Microsoft.AspNetCore.Mvc;
using TalepYonetimi.Application.AbstractRepositories.Demands;

namespace TalepYonetimi.Presentation.Controllers
{
    public class DemandController : Controller
    {
        private readonly IDemandWriteRepository demandWriteRepository;
        public DemandController(IDemandWriteRepository _demandWriteRepository)
        {
            demandWriteRepository = _demandWriteRepository;
        }

        [HttpPost]
        public IActionResult Create()
        {
            var demandProduct = HttpContext.Request.Form["product"].ToString(); // request property si httpRequest sınıfı üzerinden geliyor. request
                                                                                // üzerinden veri çekmemizi sağlıyor. burada ui layout içindeki
                                                                                // form üzerinde name değeri product olan form çıktısını çekiyoruz.
            var demandType = HttpContext.Request.Form["demandType"].ToString();
            var demandMessage = HttpContext.Request.Form["message"].ToString();

            return View();
        }
    }
}
