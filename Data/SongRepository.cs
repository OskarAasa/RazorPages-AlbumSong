using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Data
{
    public class SongRepository : ISong
    {
        private readonly AlbumSongContext albumSongContext;

        public SongRepository(AlbumSongContext albumSongContext)
        {
            this.albumSongContext = albumSongContext;
        }
        public void Add(Song song)
        {
            albumSongContext.Song.Add(song);
            albumSongContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var tempSong = GetById(id);
            if (tempSong != null)
            {
                albumSongContext.Song.Remove(tempSong);
                albumSongContext.SaveChanges();
            }
        }

        public List<Song> GetAll()
        {
            return albumSongContext.Song.OrderBy(x => x.SongId).ToList();
        }

        public Song GetById(int? id)
        {
            return albumSongContext.Song.First(x => x.SongId == id);
        }

        public void Update(Song song)
        {
            albumSongContext.Song.Update(song);
            albumSongContext.SaveChanges();
        }
    }
}
