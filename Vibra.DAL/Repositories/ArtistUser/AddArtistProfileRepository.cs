using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vibra.DAL.Context;
using Vibra.DAL.Interfaces.ArtistUser;
using Vibra.Domain.Artist;

namespace Vibra.DAL.Repositories.ArtistUser
{
    public class AddArtistProfileRepository : IAddArtistProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AddArtistProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ArtistEntity> AddArtistProfileAsync(ArtistEntity artistEntity)
        {
            await _dbContext.Artists.AddAsync(artistEntity);
            await _dbContext.SaveChangesAsync();
            return artistEntity;
        }

    
    }
}