using Microsoft.AspNetCore.Mvc;

namespace Blog.Web
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}