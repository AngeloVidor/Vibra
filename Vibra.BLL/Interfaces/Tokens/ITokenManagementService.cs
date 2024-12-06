using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vibra.BLL.DTOs;

namespace Vibra.BLL.Interfaces.Tokens
{
    public interface ITokenManagementService
    {
        Task<string> GenerateToken(StandardUserDto standardUserDto);
    }
}