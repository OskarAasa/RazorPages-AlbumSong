using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Data
{
    public class AlbumSongContext : DbContext
    {
        public AlbumSongContext (DbContextOptions<AlbumSongContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAlbumSong.Models.Record> Record { get; set; } = default!;

        public DbSet<RazorPagesAlbumSong.Models.Song> Song { get; set; } = default!;
    }
}
