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

namespace RazorPagesAlbumSong.Pages.Record
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

        public IList<Models.Record> Records { get; set; } = default!;
        public IList<Models.Song> Song { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (recordRepo != null)
            {
                Records = recordRepo.GetAll().OrderBy(x=>x.ArtistName)
                    .ThenByDescending(x=>x.ReleaseDate).ToList();
            }
            if (songRepo != null)
            {
                Song = songRepo.GetAll();
            }
            
        }
    }
}
