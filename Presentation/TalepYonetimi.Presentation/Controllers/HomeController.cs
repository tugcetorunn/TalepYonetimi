using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalepYonetimi.Application.Commands.Customers;
using TalepYonetimi.Application.Commands.Demands;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
