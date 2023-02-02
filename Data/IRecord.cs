using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Data
{
    public interface IRecord
    {
        public Record GetById(int? id);
        public List<Record> GetAll();
        public void Add(Record record);
        public void Update(Record record);
        public void Delete(int? id);


    }
}
