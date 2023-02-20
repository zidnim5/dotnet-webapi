using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Models;
using dotnet_webapi.Dtos.CharacterDto;



namespace dotnet_webapi.Services.CharacterService
{
     public interface ICharacterService
     {
          Task<ServiceResponse<List<CharacterDto>>> GetAllCharacter();
          Task<ServiceResponse<CharacterDto?>> GetCharacter(int id);
          Task<ServiceResponse<List<CharacterDto>>> AddCharacter(CharacterDto newCaracter);
          Task<ServiceResponse<CharacterDto>> UpdateCharacter(UpdateCharcterDto updateCharacter);
          Task<ServiceResponse<List<CharacterDto>>> DeleteCharacter(int id);
     }
}