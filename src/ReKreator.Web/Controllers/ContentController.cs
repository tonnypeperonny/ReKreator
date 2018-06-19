using System.Linq;
using System.Web.Mvc;
using PagedList;
using ReKreator.Web.Stubs;

namespace ReKreator.Web.Controllers
{
    public class ContentController : Controller
    {
        private readonly IStubsFactory factory;
        public ContentController(IStubsFactory stub)
        {
            this.factory = stub;
        }
        
        [HttpGet]
        public ActionResult DisplayAllFeaturedUserEvents(int? page)
        {
            const int pageSize = 12;
            var pageNumber = page ?? 1;

            var concerts = factory.CreateConcerts().Where(p => p.IsFavorite);
            var movies = factory.CreateMovie().Where(p => p.IsFavorite);
            var specatacle = factory.CreateSpectacle().Where(p => p.IsFavorite);

            var result = concerts.Concat(movies).Concat(specatacle);

            return View("Featured/DisplayAllFeaturedUserEvents", result.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult DisplayAllMovies(int? page)
        {
            var pageSize = User.Identity.IsAuthenticated? 8 : 12;
            var pageNumber = page ?? 1;

            return View("Movies/DisplayAllMovies", factory.CreateMovie().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult DisplayFeaturedMovies()
        {
            var result = factory.CreateMovie().Where(p => p.IsFavorite).ToList();
            return PartialView("Movies/DisplayFeaturedMovies", result.Count < 4 ? result: result.GetRange(0, 4));
        }

        [HttpGet]
        public ActionResult DisplayAllConcerts(int? page)
        {
            var pageSize = User.Identity.IsAuthenticated ? 8 : 12;
            var pageNumber = page ?? 1;

            return View("Concerts/DisplayAllConcerts", factory.CreateConcerts().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult DisplayFeaturedConcerts()
        {
            var result = factory.CreateConcerts().Where(p => p.IsFavorite).ToList();
            return PartialView("Concerts/DisplayFeaturedConcerts", result.Count < 4 ? result : result.GetRange(0, 4));
        }

        [HttpGet]
        public ActionResult DisplayAllSpectacle(int? page)
        {
            var pageSize = User.Identity.IsAuthenticated ? 8 : 12;
            var pageNumber = page ?? 1;

            return View("Spectacles/DisplaySpectacles", factory.CreateSpectacle().ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult DisplayFeaturedSpectacle()
        {
            var result = factory.CreateSpectacle().Where(p => p.IsFavorite).ToList();
            return PartialView("Spectacles/DisplayFeaturedSpectacles", result.Count < 4 ? result : result.GetRange(0, 4));
        }
    }
}