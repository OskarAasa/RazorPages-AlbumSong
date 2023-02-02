using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using RazorPagesAlbumSong.Data;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Pages.Song
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
            if (recordRepo.GetAll().Count == 0)
            {
                return RedirectToPage("./Index");
            }
            ViewData["Records"] = new SelectList(recordRepo.GetAll(), "RecordId", "AlbumName");
            return Page();
        }

        [BindProperty]
        public Models.Song Song { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || songRepo == null || Song == null)
            {
                return Page();
            }
            var record = recordRepo.GetById(Song.RecordId);
            if (record != null)
            {
                record.Songs.Add(Song);
                songRepo.Add(Song);
                recordRepo.Update(record);
            }
            

            return RedirectToPage("./Index");
        }
    }
}
