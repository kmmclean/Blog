using System.Threading.Tasks;
using Blog.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostViewModelService _postViewModelService;

        public HomeController(IPostViewModelService postViewModelService)
        {
            _postViewModelService = postViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postViewModelService.GetRecentPostsAsync();
            return View(posts);
        }
    }
}