using Microsoft.AspNetCore.Mvc;

namespace TalepYonetimi.Presentation.Views.Home.Components.Demand
{
    public class DemandViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
