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
    public class DeleteModel : PageModel
    {
        private readonly ISong songRepo;

        public DeleteModel(ISong songRepo)
        {
            this.songRepo = songRepo;
        }

        [BindProperty]
      public Models.Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || songRepo == null)
            {
                return NotFound();
            }

            var song = songRepo.GetById(id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || songRepo == null)
            {
                return NotFound();
            }
            var song = songRepo.GetById(id);
            if (song != null)
            {
                Song = song;
                songRepo.Delete(id);
            }

            return RedirectToPage("/Record/Details", new { id = Song.RecordId });
        }
    }
}
