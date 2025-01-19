using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Commands.Customers;
using TalepYonetimi.Application.Dtos;

namespace TalepYonetimi.Application.MappingProfiles
{
    public class CreateCustomerCommandMappingProfile : Profile
    {
        public CreateCustomerCommandMappingProfile()
        {
            CreateMap<CreateCustomerCommand, CustomerDto>(); // demandController da demand e kayıt etmek için customerDto yu newlememek
                                                             // için bu maplemeyi kullanacağız.
        }
    }
}
