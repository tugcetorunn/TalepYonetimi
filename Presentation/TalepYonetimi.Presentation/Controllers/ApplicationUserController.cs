using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalepYonetimi.Application.Commands.ApplicationUsers;

namespace TalepYonetimi.Presentation.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IMediator mediator;
        public ApplicationUserController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            LoginApplicationUserCommand command = new()
            {
                Email = email,
                Password = password
            };

            var loginResult = await mediator.Send(command);

            if (loginResult.Succeeded == false)
            {
                ModelState.AddModelError("", "Giriş bilgileri hatalı.");
                return View();
            }

            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(string name, string lastname, string username, string email, string phone, string password, string passwordConfirm)
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
                ModelState.AddModelError("", "Kişi bilgileri kaydedilemedi.");
                return View();
            }

            return RedirectToAction("LogIn");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
