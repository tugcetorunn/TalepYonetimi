using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalepYonetimi.Application.Commands.Customers;
using TalepYonetimi.Application.Commands.Demands;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Application.Queries.Customers;
using TalepYonetimi.Domain.Enums;

namespace TalepYonetimi.Presentation.Controllers
{
    public class DemandController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public DemandController(IMediator _mediator, IMapper _mapper)
        {
            mediator = _mediator;
            mapper = _mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            // talep oluşturma formunu döner
            // enum ları view e göndererek dinamik bir yapıda sunuyoruz.
            ViewBag.DemandTypes = Enum.GetValues(typeof(DemandType));
            ViewBag.Products = Enum.GetValues(typeof(Product));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string lastname, string email, string phone, int product, int demandType, string message)
        {
            var existThisCustomer = await mediator.Send(new GetCustomerByPhoneNumberQuery { PhoneNumber = phone }); // gelen bilgilerdeki müşteriyi db
                                                                                                                    // mizde olup olmadığına göre kontrol

            CustomerDto customerDto; // demand için kullanacağız.

            if (existThisCustomer == null) // bu customer db mizde yoksa kaydediyoruz
            {
                var customerCommand = new CreateCustomerCommand
                {
                    Name = name,
                    Lastname = lastname,
                    Email = email,
                    PhoneNumber = phone
                };
                
                var customerResult = await mediator.Send(customerCommand);
                
                if (customerResult == null)
                {
                    ModelState.AddModelError("", "Müşteri bilgileri kaydedilemedi.");
                    return View();
                }

                customerDto = customerResult; // customer db mizde varsa bu dto yu demandda kullanacağız.
            }
            else // db de varsa bu bilgiler kullanılır.
            {
                customerDto = existThisCustomer;
            }

            var demandCommand = new CreateDemandCommand
            {
                DemandType = (DemandType)demandType,
                Product = (Product)product,
                Message = message,
                CustomerId = customerDto.Id
            };

            var demandResult = await mediator.Send(demandCommand);

            if (demandResult)
            {
                return RedirectToAction("Success");
            }

            ModelState.AddModelError("", "Talep kaydedilemedi.");
            return View();
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
