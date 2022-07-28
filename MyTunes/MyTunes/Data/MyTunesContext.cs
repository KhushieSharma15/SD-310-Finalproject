using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTunes.Models;

namespace MyTunes.Data
{
    public class MyTunesContext : DbContext
    {
        public MyTunesContext (DbContextOptions<MyTunesContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artist { get; set; } = default!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersPlaylist> UsersPlaylists { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; }
    }
}
