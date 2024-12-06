using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vibra.Domain.Artist;
using Vibra.Domain.User;

namespace Vibra.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<StandardUserEntity> StandardUsers { get; set; }
        public DbSet<ArtistEntity> Artists { get; set; }
    }
}
