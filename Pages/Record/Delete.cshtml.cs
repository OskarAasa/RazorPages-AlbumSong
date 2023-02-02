using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAlbumSong.Data;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Pages.Record
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesAlbumSong.Data.AlbumSongContext _context;
        private readonly IRecord recordRepo;
        private readonly ISong songRepo;

        public DeleteModel(RazorPagesAlbumSong.Data.AlbumSongContext context, IRecord recordRepo, ISong songRepo)
        {
            _context = context;
            this.recordRepo = recordRepo;
            this.songRepo = songRepo;
        }

        [BindProperty]
      public Models.Record Record { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || recordRepo == null)
            {
                return NotFound();
            }

            var record = recordRepo.GetById(id);

            if (record == null)
            {
                return NotFound();
            }
            else 
            {
                Record = record;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || recordRepo == null)
            {
                return NotFound();
            }

            recordRepo.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
