using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vibra.Domain.Tracks;

namespace Vibra.DAL.Interfaces.Tracks
{
    public interface IAddTrackRepository
    {
        Task<TrackEntity> AddTrackAsync(TrackEntity track);
        Task<List<TrackEntity>> GetArtistTracksAsync(int artistId);
    }
}
