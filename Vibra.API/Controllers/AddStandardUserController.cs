using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vibra.BLL.DTOs;
using Vibra.BLL.Interfaces;
using Vibra.BLL.Interfaces.Tokens;

namespace Vibra.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddStandardUserController : ControllerBase
    {
        private readonly IAddStandardUserService _addStandardUserService;
        private readonly IMapper _mapper;
        private readonly ITokenManagementService _tokenManagementService;

        public AddStandardUserController(
            IMapper mapper,
            IAddStandardUserService addStandardUserService,
            ITokenManagementService tokenManagementService
        )
        {
            _addStandardUserService = addStandardUserService;
            _mapper = mapper;
            _tokenManagementService = tokenManagementService;
        }

        [HttpPost("Register-StandardUser")]
        public async Task<IActionResult> RegisterStandardUser(
            [FromBody] AddStandardUserDto addStandardUserDto
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var addedUser = await _addStandardUserService.AddStandardUserAsync(
                    addStandardUserDto
                );
                return Ok(addedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] StandardUserLoginDto standardUserLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dto = _mapper.Map<StandardUserDto>(standardUserLoginDto);
            var user = await _addStandardUserService.ValidateUserAsync(dto);
        
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }
            
            var token = await _tokenManagementService.GenerateToken(user);
            return Ok(new {Token = token, User = user});

        }
    }
}
