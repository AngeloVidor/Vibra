using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vibra.BLL.DTOs;

namespace Vibra.BLL.Interfaces.ArtistUser
{
    public interface IAddArtistProfileService
    {
        Task<AddArtistProfileDto> AddArtistProfileAsync(AddArtistProfileDto addArtistProfileDto);
    }
}