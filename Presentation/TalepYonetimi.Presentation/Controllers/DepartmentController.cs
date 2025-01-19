using Microsoft.AspNetCore.Mvc;

namespace TalepYonetimi.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
