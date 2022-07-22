using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PORTPROJECTWEBAPI.Data;
using PORTPROJECTWEBAPI.Models;

namespace PORTPROJECTWEBAPI.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<SlotData, SlotClass>().ReverseMap();
            CreateMap<UserData, UserClass>().ReverseMap();
        }

    }
}
