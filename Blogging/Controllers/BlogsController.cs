using Microsoft.AspNetCore.Mvc;

namespace Blogging.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
