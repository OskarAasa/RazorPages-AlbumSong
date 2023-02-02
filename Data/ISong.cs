using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Data
{
    public interface ISong
    {
        public Song GetById(int? id);
        public List<Song> GetAll();
        public void Add(Song song);
        public void Update(Song song);
        public void Delete(int? id);
    }
}
