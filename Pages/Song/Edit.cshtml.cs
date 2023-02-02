using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesAlbumSong.Data;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Pages.Song
{
    public class EditModel : PageModel
    {
        private readonly ISong songRepo;
        private readonly IRecord recordRepo;

        public EditModel(ISong songRepo, IRecord recordRepo)
        {
            this.songRepo = songRepo;
            this.recordRepo = recordRepo;
        }

        [BindProperty]
        public Models.Song Song { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || songRepo == null)
            {
                return NotFound();
            }

            var song =  songRepo.GetById(id);
            if (song == null)
            {
                return NotFound();
            }
            Song = song;
            ViewData["Records"] = new SelectList(recordRepo.GetAll(), "RecordId", "AlbumName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            songRepo.Update(Song);

            return RedirectToPage("/Record/Details", new { id = Song.RecordId });
        }                
    }
}
