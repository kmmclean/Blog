using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Web.ViewModels;

namespace Blog.Web.Interfaces
{
    public interface IPostViewModelService
    {
        Task<IEnumerable<PostViewModel>> GetRecentPostsAsync();
    }
}