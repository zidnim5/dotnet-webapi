using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_webapi.Models;
using dotnet_webapi.Services.CharacterService;
using dotnet_webapi.Dtos.CharacterDto;

namespace dotnet_webapi.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class CharacterController : ControllerBase
     {

          private ICharacterService _characterService;


          public CharacterController(ICharacterService characterService)
          {
               _characterService = characterService;
          }

          [HttpGet]
          [Route("{id}")]
          public async Task<ActionResult<ServiceResponse<CharacterDto>>> GetSingle(int id)
          {
               return Ok(await _characterService.GetCharacter(id));
          }


          [HttpGet]
          [Route("GetAll")]
          public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> Get()
          {
               return Ok(await _characterService.GetAllCharacter());
          }

          [HttpPost]
          public async Task<ActionResult<ServiceResponse<List<CharacterDto>>>> Add(CharacterDto newCharacter)
          {
               return Ok(await _characterService.AddCharacter(newCharacter));
          }


          [HttpPut]
          public async Task<ActionResult<ServiceResponse<CharacterDto>>> Update(UpdateCharcterDto updateCharacter)
          {
               return Ok(await _characterService.UpdateCharacter(updateCharacter));
          }


          [HttpDelete]
          public async Task<ActionResult<ServiceResponse<CharacterDto>>> Delete(int id)
          {
               return Ok(await _characterService.DeleteCharacter(id));
          }


     }
}