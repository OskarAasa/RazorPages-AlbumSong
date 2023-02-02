using System.ComponentModel;

namespace RazorPagesAlbumSong.ViewModels
{
    public class SongRecordVM
    {
        public int SongId { get; set; }
        public int RecordId { get; set; }
        [DisplayName("Artist")]
        public string ArtistName { get; set; }
        public string Title { get; set; }
        public TimeSpan Lenght { get; set; }

        [DisplayName("Release date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayName("Album")]
        public string AlbumName { get; set; }

        [DisplayName("Record company")]
        public string RecordCompany { get; set; }
    }
}
