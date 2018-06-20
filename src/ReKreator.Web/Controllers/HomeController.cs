using System.Web.Mvc;

namespace ReKreator.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index() => View("Index");
    }
}