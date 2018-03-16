using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}