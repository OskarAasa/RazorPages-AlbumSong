using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAlbumSong.Data;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Pages.Song
{
    public class DetailsModel : PageModel
    {
        private readonly ISong songRepo;
        private readonly IRecord recordRepo;

        public DetailsModel(ISong songRepo, IRecord recordRepo)
        {
            this.songRepo = songRepo;
            this.recordRepo = recordRepo;
        }

      public Models.Song Song { get; set; } = default!; 
      public Models.Record Record { get; set; } = default!; 
      public ViewModels.SongRecordVM SongRecordVM { get; set; } = new ViewModels.SongRecordVM();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || songRepo == null)
            {
                return NotFound();
            }

            var song = songRepo.GetById(id);
            SongRecordVM.SongId = song.SongId;
            SongRecordVM.RecordId = song.RecordId;
            SongRecordVM.Title = song.Title;
            SongRecordVM.Lenght = song.Lenght;
            SongRecordVM.AlbumName = recordRepo.GetById(song.RecordId).AlbumName;
            SongRecordVM.ArtistName = recordRepo.GetById(song.RecordId).ArtistName;
            SongRecordVM.RecordCompany = recordRepo.GetById(song.RecordId).RecordCompany;

            if (song == null)
            {
                return NotFound();
            }
            else 
            {
                Song = song;
            }
            return Page();
        }
    }
}
