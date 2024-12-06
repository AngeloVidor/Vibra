using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Vibra.BLL.DTOs;
using Vibra.BLL.Interfaces.Tokens;

namespace Vibra.BLL.Services.Tokens
{
    public class TokenManagementService : ITokenManagementService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TokenManagementService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(StandardUserDto standardUserDto)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, standardUserDto.Id.ToString()),
                new Claim(ClaimTypes.Name, standardUserDto.Username.ToString()),
            };

            var secretKey = _configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    _configuration.GetValue<int>("Jwt:DurationInMinutes")
                ),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
