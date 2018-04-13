using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Web.Interfaces;
using Blog.Web.ViewModels;

namespace Blog.Web.Services
{
    public class PostViewModelService : IPostViewModelService
    {
        private readonly IRepository<Post> _postRepository;

        public PostViewModelService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostViewModel>> GetRecentPostsAsync()
        {
            var posts = await _postRepository.GetAllAsync();

            var postSelect =
                from p in posts
                orderby p.CreatedOn descending
                select new PostViewModel
                {
                    Title = p.Title,
                    Content = p.Content,
                    Author = p.Author,
                    CreatedOn = p.CreatedOn
                };
            
            return postSelect.ToList();
        }
    }
}