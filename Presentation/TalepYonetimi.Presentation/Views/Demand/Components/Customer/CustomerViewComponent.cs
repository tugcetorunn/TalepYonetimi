using Microsoft.AspNetCore.Mvc;

namespace TalepYonetimi.Presentation.Views.Home.Components.Customer
{
    public class CustomerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
