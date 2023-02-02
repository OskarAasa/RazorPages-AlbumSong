using Microsoft.AspNetCore.Mvc;
using RazorPagesAlbumSong.Data;

namespace RazorPagesAlbumSong.Components
{
    public class SongsViewComponent: ViewComponent
    {
        private readonly ISong songRepo;
        private readonly IRecord recordRepo;

        public SongsViewComponent(ISong songRepo, IRecord recordRepo)
        {
            this.songRepo = songRepo;
            this.recordRepo = recordRepo;
        }

        public IViewComponentResult Invoke(int recordId)
        {
            var record = songRepo.GetAll().OrderByDescending(x => x.SongId);

            if (record != null)
            {

            }

            return View();
        }
    }
}
