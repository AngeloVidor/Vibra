using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vibra.BLL.DTOs;

namespace Vibra.BLL.Interfaces
{
    public interface IAddStandardUserService
    {
        Task<AddStandardUserDto> AddStandardUserAsync(AddStandardUserDto addStandardUserDto);
        Task<StandardUserDto> ValidateUserAsync(StandardUserDto standardUserDto);

    }
}
