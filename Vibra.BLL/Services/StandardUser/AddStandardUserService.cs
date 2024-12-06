using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vibra.BLL.DTOs;
using Vibra.BLL.Interfaces;
using Vibra.DAL.Interfaces;
using Vibra.Domain.User;

namespace Vibra.BLL.Services
{
    public class AddStandardUserService : IAddStandardUserService
    {
        private readonly IAddStandardUserRepository _addStandardUserRepository;
        private readonly IMapper _mapper;
        public AddStandardUserService(IAddStandardUserRepository addStandardUserRepository, IMapper mapper)
        {
            _addStandardUserRepository = addStandardUserRepository;
            _mapper = mapper;
        }
        public async Task<AddStandardUserDto> AddStandardUserAsync(AddStandardUserDto addStandardUserDto)
        {
            var userEmail = await _addStandardUserRepository.GetUserByEmailAsync(addStandardUserDto.Email);
            if(userEmail != null)
            {
                throw new Exception($"Email {addStandardUserDto.Email} is already in use");
            }

            addStandardUserDto.Password = BCrypt.Net.BCrypt.HashPassword(addStandardUserDto.Password);
            var standardUserEntity = _mapper.Map<StandardUserEntity>(addStandardUserDto);
            var addedStandardUser = await _addStandardUserRepository.AddStandardUserAsync(standardUserEntity);
            return _mapper.Map<AddStandardUserDto>(addedStandardUser);
        }

        public async Task<StandardUserDto> ValidateUserAsync(StandardUserDto standardUserDto)
        {
            var userEntity = await _addStandardUserRepository.GetUserByEmailAsync(standardUserDto.Email);
            if(userEntity == null || !BCrypt.Net.BCrypt.Verify(standardUserDto.Password, userEntity.Password))
            {
                return null;
            }
            return _mapper.Map<StandardUserDto>(userEntity);
        }

    }
}