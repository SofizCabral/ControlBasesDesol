using System.Web;
using System.Web.Mvc;

namespace ControlBasesDesol.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}