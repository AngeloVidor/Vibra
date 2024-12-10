using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vibra.DAL.Context;
using Vibra.DAL.Interfaces.Tracks;
using Vibra.Domain.Tracks;

namespace Vibra.DAL.Repositories.Tracks
{
    public class AddTrackRepository : IAddTrackRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AddTrackRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TrackEntity> AddTrackAsync(TrackEntity track)
        {
            await _dbContext.Tracks.AddAsync(track);
            await _dbContext.SaveChangesAsync();
            return track;
        }

        public async Task<List<TrackEntity>> GetArtistTracksAsync(int artistId)
        {
            var artistTracks = await _dbContext.Tracks.Where(a => a.ArtistId == artistId).ToListAsync();
            return artistTracks;

        }
    }
}
