using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_webapi.Models;
using dotnet_webapi.Dtos.CharacterDto;

namespace dotnet_webapi
{
     public class AutoMapperProfile : Profile
     {
          public AutoMapperProfile()
          {
               CreateMap<Character, CharacterDto>();
               CreateMap<CharacterDto, Character>();
               CreateMap<UpdateCharcterDto, Character>();
          }
     }
}