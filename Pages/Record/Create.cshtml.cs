using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAlbumSong.Data;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Pages.Record
{
    public class CreateModel : PageModel
    {
        private readonly IRecord recordRepo;
        private readonly ISong songRepo;

        public CreateModel(IRecord recordRepo, ISong songRepo)
        {
            this.recordRepo = recordRepo;
            this.songRepo = songRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Record Record { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || recordRepo == null || Record == null)
            {
                return Page();
            }

            recordRepo.Add(Record);

            return RedirectToPage("./Index");
        }
    }
}
