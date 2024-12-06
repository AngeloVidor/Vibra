using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Vibra.BLL.DTOs;
using Vibra.BLL.Interfaces.ArtistUser;
using Vibra.DAL.Interfaces.ArtistUser;
using Vibra.Domain.Artist;

namespace Vibra.BLL.Services.ArtistUser
{
    public class AddArtistProfileService : IAddArtistProfileService
    {
        private readonly IAddArtistProfileRepository _addArtistProfileRepository;
        private readonly IMapper _mapper;
        public AddArtistProfileService(IMapper mapper, IAddArtistProfileRepository addArtistProfileRepository)
        {
            _addArtistProfileRepository = addArtistProfileRepository;
            _mapper = mapper;
        }

        public async Task<AddArtistProfileDto> AddArtistProfileAsync(AddArtistProfileDto addArtistProfileDto)
        {
            if(addArtistProfileDto == null)
            {
                throw new ArgumentNullException("addArtistProfile cannot be null");
            }
            var artistEntity = _mapper.Map<ArtistEntity>(addArtistProfileDto);
            var addedArtistProfile = await _addArtistProfileRepository.AddArtistProfileAsync(artistEntity);
            return _mapper.Map<AddArtistProfileDto>(addedArtistProfile);
        }
    }
}