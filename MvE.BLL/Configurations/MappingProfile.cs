using AutoMapper;
using MvE.BLL.DTOs;
using MvE.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvE.BLL.Configurations
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<CharacterSheet, CharacterSheetDTO>();
            CreateMap<CharacterSheetDTO, CharacterSheet>().ForMember(x=>x.Id, opt => opt.Ignore());
        }
    }
}
