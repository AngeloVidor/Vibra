using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Vibra.DAL.Context;
using Vibra.DAL.Interfaces;
using Vibra.Domain.User;

namespace Vibra.DAL.Repositories
{
    public class AddStandardUserRepository : IAddStandardUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddStandardUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StandardUserEntity> AddStandardUserAsync(StandardUserEntity standardUser)
        {
            await _dbContext.StandardUsers.AddAsync(standardUser);
            await _dbContext.SaveChangesAsync();
            return standardUser;
        }

        public async Task<StandardUserEntity> GetUserByEmailAsync(string email)
        {
            return await _dbContext.StandardUsers.FirstOrDefaultAsync(em => em.Email == email);
        }
    }
}
