using System.Diagnostics;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Starpholio.Models;

namespace Starpholio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult GetImage()
        {
            string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "imagens/starpholio 1.png");
            byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
            return File(imageData, "Image/png");
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}