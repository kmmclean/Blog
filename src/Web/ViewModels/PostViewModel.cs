using System;

namespace Blog.Web.ViewModels
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}