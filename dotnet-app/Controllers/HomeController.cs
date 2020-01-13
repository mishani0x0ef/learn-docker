using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Learn.Docker.Models;
using Learn.Docker.Repositories;

namespace Learn.Docker.Controllers
{
    public class HomeController : Controller
    {
        private readonly BloggingContext _context;

        public HomeController(BloggingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Blogs()
        {
            var blogs = _context.Blogs.Select(blog => blog);
            return View(blogs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
