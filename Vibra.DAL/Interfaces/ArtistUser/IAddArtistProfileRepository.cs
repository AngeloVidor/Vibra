using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vibra.Domain.Artist;

namespace Vibra.DAL.Interfaces.ArtistUser
{
    public interface IAddArtistProfileRepository
    {
        Task<ArtistEntity> AddArtistProfileAsync(ArtistEntity artistEntity);
    }
}