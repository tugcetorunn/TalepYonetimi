using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalepYonetimi.Application.Commands.Demands;
using TalepYonetimi.Application.Queries.Demands;

namespace TalepYonetimi.Presentation.Controllers
{
    public class AdminDemandController : Controller
    {
        private readonly IMediator mediator;
        public AdminDemandController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllDemands() // taleplerin adminde gösterilmesi
        {
            var demands = await mediator.Send(new GetAllDemandQuery());

            return View(demands);
        }

        [HttpPost]
        public async Task<IActionResult> ShowAllDemands(UpdateDepartmentInDemandCommand command) // taleplerin admin tarafından departmanlara gönderilmesi
        {
            if (command != null)
            {
                var result = await mediator.Send(command);
                return View(result);
            }

            return BadRequest("Geçersiz veri!");
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllDemandsByDepartment(int userId) // yetkin olan kişilerin talepleri görmesi
        {
            // userManager ile userId nin alınması lazım.
            var demands = await mediator.Send(new GetAllDemandWithAuthorizeQuery() { UserId = userId});

            return View(demands);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDemandByDepartment(int demandId, UpdateDemandCommand command) // yetkin olan kişilerin talepleri düzenlemesi
        {
            command.DemandId = demandId;
            var result = await mediator.Send(command);
            return View(result);
        }
        public async Task<IActionResult> DeleteDemandByDepartment(DeleteDemandCommand command)
        {
            var result = await mediator.Send(command);
            return View(result);
        }
    }
}
