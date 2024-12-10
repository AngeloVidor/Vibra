using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vibra.BLL.DTOs
{
    public class GetArtistTrackDto
    {
        [Key]
        public int Id { get; set; }
        public string TrackTitle { get; set; }
        public string TrackDescription { get; set; }
        public int ReleaseYear { get; set; }
        public int ArtistId { get; set; }
    }
}