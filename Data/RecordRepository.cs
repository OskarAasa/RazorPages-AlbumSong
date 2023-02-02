using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Data
{
    public class RecordRepository : IRecord
    {
        private readonly AlbumSongContext albumSongContext;

        public RecordRepository(AlbumSongContext albumSongContext)
        {
            this.albumSongContext = albumSongContext;
        }
        public void Add(Record record)
        {
            albumSongContext.Record.Add(record);
            albumSongContext.SaveChanges();
        }

        public void Delete(int? id)
        {
            var record = GetById(id);
            if (record != null)
            {
                albumSongContext.Record.Remove(record);
                albumSongContext.SaveChanges();
            }            
        }

        public List<Record> GetAll()
        {
            return albumSongContext.Record.OrderBy(x=>x.RecordId).ToList();
        }

        public Record GetById(int? id)
        {
            return albumSongContext.Record.First(x=>x.RecordId == id);
        }
        public void Update(Record record)
        {
            albumSongContext.Record.Update(record);
            albumSongContext.SaveChanges();
        }
    }
}
