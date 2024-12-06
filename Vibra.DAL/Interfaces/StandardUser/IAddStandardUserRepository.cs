using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vibra.Domain.User;

namespace Vibra.DAL.Interfaces
{
    public interface IAddStandardUserRepository
    {
        Task<StandardUserEntity> AddStandardUserAsync(StandardUserEntity standardUser);
        Task<StandardUserEntity> GetUserByEmailAsync(string email);
    }
}
