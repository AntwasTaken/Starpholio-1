using Microsoft.AspNetCore.Mvc;

using Starpholio.Views.Home;

namespace Starpholio.Controllers
{
    public class LoggedINController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/page1.cshtml");
        }
    }
}
