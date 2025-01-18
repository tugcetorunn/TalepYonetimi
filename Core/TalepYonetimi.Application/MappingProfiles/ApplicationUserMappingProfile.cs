using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities.Admin;

namespace TalepYonetimi.Application.MappingProfiles
{
    public class ApplicationUserMappingProfile : Profile
    {
        // Automapper 3. adım mapping profile class ları oluşturulur. profile base classı implement edilir. createMap metodu constructor içinde çalışır.
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
                                                            // tersi için de (dto dan entity ye) uygulanması için reverseMap kullanılır.
        }
    }
}
