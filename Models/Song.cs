using Microsoft.Build.Framework;

namespace RazorPagesAlbumSong.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public int RecordId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public TimeSpan Lenght { get; set; }
        [Required]
        public string Author { get; set; }

    }
}
