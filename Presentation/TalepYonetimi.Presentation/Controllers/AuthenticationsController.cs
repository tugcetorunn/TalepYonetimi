using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalepYonetimi.Application.Commands.ApplicationUsers;

namespace TalepYonetimi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthenticationsController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromQuery] string email, [FromQuery] string password)
        {
            LoginApplicationUserCommand command = new()
            {
                Email = email,
                Password = password
            };

            var loginResult = await mediator.Send(command);

            if (loginResult.Succeeded == false)
            {
                return BadRequest("Giriş bilgileri hatalı.");
            }

            return Ok(loginResult);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromQuery] string name, [FromQuery] string lastname, [FromQuery] string username, [FromQuery] string password, [FromQuery] string email, [FromQuery] string phone, [FromQuery] string passwordConfirm)
        {
            CreateApplicationUserCommand command = new()
            {
                Name = name,
                LastName = lastname,
                UserName = username,
                Email = email,
                PhoneNumber = phone,
                Password = password,
                PasswordConfirm = passwordConfirm
            };
            var signUpResult = await mediator.Send(command);

            if (signUpResult.Succeeded == false)
            {
                return BadRequest("Kişi bilgileri hatalı.");
            }

            return Ok(signUpResult);
        }
    }
}
