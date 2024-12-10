using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vibra.Domain.Artist;
using Vibra.Domain.Tracks;

namespace Vibra.Domain.Albums
{
    public class AlbumEntity
    {
        public int Id { get; set; }
        public string AlbumTitle { get; set; }
        public string AlbumDescription { get; set; }
        public int ReleaseYear { get; set; }

        public virtual ICollection<TrackEntity> AlbumTracks { get; set; } = new List<TrackEntity>();
        public virtual ArtistEntity Artist { get; set; }
        public int ArtistId { get; set; }
    }
}