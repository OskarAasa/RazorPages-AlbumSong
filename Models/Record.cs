using Microsoft.Build.Framework;
using System.ComponentModel;

namespace RazorPagesAlbumSong.Models
{
    public class Record
    {
        public int RecordId { get; set; }

        [Required, DisplayName("Artist")]
        public string ArtistName { get; set; }

        [Required, DisplayName("Album")]
        public string AlbumName { get; set; }

        [Required, DisplayName("Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required, DisplayName("Record company")]
        public string RecordCompany { get; set; }
        public List<Song> Songs { get; set; } = new();

    }
}
