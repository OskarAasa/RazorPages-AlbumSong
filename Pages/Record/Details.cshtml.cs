using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RazorPagesAlbumSong.Data;
using RazorPagesAlbumSong.Models;

namespace RazorPagesAlbumSong.Pages.Record
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

        public Models.Record Record { get; set; } = default!;
        [BindProperty]
        public Models.Song Song { get; set; } = new();

        public IActionResult OnGet(int? id)
        {
            if (id == null || recordRepo == null)
            {
                return NotFound();
            }
            var record = recordRepo.GetById(id);
            record.Songs = songRepo.GetAll().Where(x => x.RecordId == record.RecordId).ToList();

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
            Song.RecordId = recordRepo.GetById(id).RecordId;
            var record = recordRepo.GetById(Song.RecordId);

            if (!ModelState.IsValid || songRepo == null || Song == null)
            {
                return Page();
            }

            if (record != null)
            {
                record.Songs.Add(Song);
                songRepo.Add(Song);
                recordRepo.Update(record);
            }
            OnGet(id);
            return Page();
        }
    }
}
