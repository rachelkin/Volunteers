using AutoMapper;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Entities;
using static DTOs.Class1;

namespace Volunteer.Service
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Class1.VolunteerPostDTO, MyVolunteer>();
            CreateMap<MyVolunteer, Class1.VolunteerDTO>()
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.Skills.Select(s => s.Name).ToList()));
        }
    }
}
