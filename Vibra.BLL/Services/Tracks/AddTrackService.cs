using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vibra.BLL.DTOs;
using Vibra.BLL.Interfaces.Tracks;
using Vibra.DAL.Interfaces.Tracks;
using Vibra.Domain.Tracks;

namespace Vibra.BLL.Services.Tracks
{
    public class AddTrackService : IAddTrackService
    {
        private readonly IAddTrackRepository _addTrackRepository;
        private readonly IMapper _mapper;

        public AddTrackService(IMapper mapper, IAddTrackRepository addTrackRepository)
        {
            _addTrackRepository = addTrackRepository;
            _mapper = mapper;
        }

        public async Task<AddTrackDto> AddTrackAsync(AddTrackDto addTrack)
        {
            if (addTrack == null)
            {
                throw new ArgumentNullException("addTrack cannot be null");
            }
            var trackEntity = _mapper.Map<TrackEntity>(addTrack);
            var addedTrack = await _addTrackRepository.AddTrackAsync(trackEntity);
            return _mapper.Map<AddTrackDto>(addedTrack);
        }

        public async Task<List<GetArtistTrackDto>> GetArtistTracksAsync(int artistId)
        {
            if(artistId <= 0)
            {
                throw new Exception("ArtistID must be a positive integer");
            }
            var artistTracks = await _addTrackRepository.GetArtistTracksAsync(artistId);
            return _mapper.Map<List<GetArtistTrackDto>>(artistTracks);
        }
    }
}
