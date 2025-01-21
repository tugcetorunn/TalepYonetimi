using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalepYonetimi.Application.Commands.Demands;
using TalepYonetimi.Application.Queries.Demands;

namespace TalepYonetimi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;
        public ValuesController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [Authorize(Roles = "SuperAdmin")] // admin, departmanına gelen talepleri günceller, siler. superadmin gelen tüm taleplere departman ataması yapar.
        [HttpGet("ShowAllDemands")]       // bu yüzden superadmin olan kişi hem superadmin hem admin olmalı.
        public async Task<IActionResult> ShowAllDemands() // taleplerin adminde gösterilmesi
        {
            var demands = await mediator.Send(new GetAllDemandQuery());

            return Ok(demands);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("UpdateDepartmentByAdmin")]
        public async Task<IActionResult> UpdateDepartmentByAdmin([FromQuery] UpdateDepartmentInDemandCommand command) // taleplerin admin tarafından departmanlara gönderilmesi
        {
            if (command != null)
            {
                var result = await mediator.Send(command);
                return Ok(result);
            }

            return BadRequest("Geçersiz veri!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("ShowAllDemandsByDepartment")]
        public async Task<IActionResult> ShowAllDemandsByDepartment() // yetkin olan kişilerin talepleri görmesi
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            int.TryParse(userIdClaim.Value, out int userId);
            var demands = await mediator.Send(new GetAllDemandWithAuthorizeQuery() { UserId = userId });

            return Ok(demands);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateDemandByDepartment")]
        public async Task<IActionResult> UpdateDemandByDepartment(int demandId, UpdateDemandCommand command) // yetkin olan kişilerin talepleri düzenlemesi
        {
            command.DemandId = demandId;
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDemandByDepartment(DeleteDemandCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
