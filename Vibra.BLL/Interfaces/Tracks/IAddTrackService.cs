using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vibra.BLL.DTOs;

namespace Vibra.BLL.Interfaces.Tracks
{
    public interface IAddTrackService
    {
        Task<AddTrackDto> AddTrackAsync(AddTrackDto addTrack);
        Task<List<GetArtistTrackDto>> GetArtistTracksAsync(int artistId);
    }
}
