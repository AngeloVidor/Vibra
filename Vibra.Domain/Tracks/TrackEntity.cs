using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vibra.Domain.Albums;
using Vibra.Domain.Artist;

namespace Vibra.Domain.Tracks
{
    public class TrackEntity
    {
        [Key]
        public int Id { get; set; }
        public string TrackTitle { get; set; }
        public string TrackDescription { get; set; }
        public int ReleaseYear { get; set; }
        public int ArtistId { get; set; }
        public virtual ArtistEntity Artist { get; set; }
        public virtual ICollection<AlbumEntity> AlbumTracks { get; set; } = new List<AlbumEntity>();
    }
}
