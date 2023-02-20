using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi.Models;
using dotnet_webapi.Dtos.CharacterDto;
using AutoMapper;
using dotnet_webapi.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi.Services.CharacterService
{
     public class CharacterService : ICharacterService
     {

          // public static List<Character> characters = new List<Character>
          // {
          //   new Character{Id=1,Name="Sam"},
          //   new Character{Id=2,Name="Max"}
          // };

          private readonly IMapper _mapper;

          private readonly DataContext _context;

          public CharacterService(IMapper mapper, DataContext context)
          {
               _mapper = mapper;
               _context = context;
          }

          public async Task<ServiceResponse<List<CharacterDto>>> AddCharacter(CharacterDto newCaracter)
          {
               var serviceResponse = new ServiceResponse<List<CharacterDto>>();
               Character character = _mapper.Map<Character>(newCaracter);
               _context.Characters.Add(character);
               await _context.SaveChangesAsync();

               serviceResponse.Data = await _context.Characters.Select(p => _mapper.Map<CharacterDto>(p)).ToListAsync();

               return serviceResponse;
          }

          public async Task<ServiceResponse<List<CharacterDto>>> GetAllCharacter()
          {
               var serviceResponse = new ServiceResponse<List<CharacterDto>>();
               serviceResponse.Data = await _context.Characters.Select(p => _mapper.Map<CharacterDto>(p)).ToListAsync();

               return serviceResponse;
          }

          public async Task<ServiceResponse<CharacterDto?>> GetCharacter(int id)
          {
               var serviceResponse = new ServiceResponse<CharacterDto?>();
               Character? character = _context.Characters?.FirstOrDefault(c => c.Id == id);

               serviceResponse.Data = _mapper.Map<CharacterDto>(character);

               return serviceResponse;
          }

          public async Task<ServiceResponse<CharacterDto>> UpdateCharacter(UpdateCharcterDto updateCharacter)
          {
               ServiceResponse<CharacterDto> serviceResponse = new ServiceResponse<CharacterDto>();

               Character? character = _context.Characters.FirstOrDefault(p => p.Id == updateCharacter.Id);
               if (character != null)
               {
                    _mapper.Map(updateCharacter, character);

                    await _context.SaveChangesAsync();
               }

               serviceResponse.Data = _mapper.Map<CharacterDto>(character);

               return serviceResponse;
          }

          public async Task<ServiceResponse<List<CharacterDto>>> DeleteCharacter(int id)
          {
               var serviceResponse = new ServiceResponse<List<CharacterDto>>();
               Character? character = _context.Characters.FirstOrDefault(p => p.Id == id);
               if (character != null)
               {
                    _context.Characters.Remove(character);

                    await _context.SaveChangesAsync();
               }

               serviceResponse.Data = await _context.Characters.Select(p => _mapper.Map<CharacterDto>(p)).ToListAsync();

               return serviceResponse;
          }
     }
}