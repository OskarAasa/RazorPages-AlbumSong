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

namespace RazorPagesAlbumSong.Pages.Record
{
    public class EditModel : PageModel
    {
        private readonly ISong songRepo;
        private readonly IRecord recordRepo;

        public EditModel(RazorPagesAlbumSong.Data.AlbumSongContext context, ISong songRepo, IRecord recordRepo)
        {
            this.songRepo = songRepo;
            this.recordRepo = recordRepo;
        }

        [BindProperty]
        public Models.Record Record { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || recordRepo == null)
            {
                return NotFound();
            }

            var record =  recordRepo.GetById(id);
            if (record == null)
            {
                return NotFound();
            }
            Record = record;
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

            recordRepo.Update(Record);

            return RedirectToPage("./Index");
        }

        
    }
}
