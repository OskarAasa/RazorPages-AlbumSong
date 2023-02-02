using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAlbumSong.Data;
using RazorPagesAlbumSong.Models;
using RazorPagesAlbumSong.ViewModels;

namespace RazorPagesAlbumSong.Pages.Song
{
    public class IndexModel : PageModel
    {
        private readonly ISong songRepo;
        private readonly IRecord recordRepo;

        public IndexModel(ISong songRepo, IRecord recordRepo)
        {
            this.songRepo = songRepo;
            this.recordRepo = recordRepo;
        }

        public IList<Models.Song> Song { get;set; } = default!;
        public IList<Models.Record> Records { get;set; } = default!;
        public IList<SongRecordVM> SongRecordVM { get; set; } = new List<SongRecordVM>();



        public async Task OnGetAsync()
        {
            if (recordRepo != null)
            {
                Records = recordRepo.GetAll();
            }
            if (songRepo != null)
            {
                Song = songRepo.GetAll();
            }
            var tempList = new List<SongRecordVM>();
            foreach (var song in Song)
            {
                foreach (var record in Records)
                {
                    if (song.RecordId == record.RecordId)
                    {
                        var tempSongRecordVM = new SongRecordVM();
                        tempSongRecordVM.ArtistName = record.ArtistName;
                        tempSongRecordVM.AlbumName = record.AlbumName;
                        tempSongRecordVM.RecordCompany = record.RecordCompany;
                        tempSongRecordVM.ReleaseDate = record.ReleaseDate;
                        tempSongRecordVM.Title = song.Title;
                        tempSongRecordVM.Lenght = song.Lenght;
                        tempSongRecordVM.RecordId = song.RecordId;
                        tempSongRecordVM.SongId = song.SongId;
                        tempList.Add(tempSongRecordVM);
                    }
                }                
            }
            SongRecordVM = tempList.OrderBy(x => x.ArtistName).ThenBy(x=>x.ReleaseDate).ThenBy(x=>x.AlbumName).ToList();
        }
    }
}
