﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalepYonetimi.Application.Dtos;
using TalepYonetimi.Domain.Entities;

namespace TalepYonetimi.Application.MappingProfiles
{
    public class DemandMappingProfile : Profile
    {
        public DemandMappingProfile()
        {
            CreateMap<Demand, DemandDto>().ReverseMap();
        }
    }
}
