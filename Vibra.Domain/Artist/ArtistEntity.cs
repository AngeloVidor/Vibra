using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vibra.Domain.User;

namespace Vibra.Domain.Artist
{
    public class ArtistEntity
    {
        [Key]
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string Biography { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; } //string por enquanto

        [NotMapped]
        [JsonIgnore]
        public StandardUserEntity User { get; set; }
        public int UserId { get; set; }
    }
}
