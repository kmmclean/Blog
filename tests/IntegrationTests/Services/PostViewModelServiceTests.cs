using System.Collections.Generic;
using Blog.Core.Entities;
using Blog.Core.Interfaces;
using Blog.Web.Interfaces;
using Blog.Web.Services;
using Moq;
using Xunit;
using System;
using System.Linq;
using Blog.Web.ViewModels;
using System.Threading.Tasks;
using FluentAssertions;

namespace Blog.IntegrationTests.Services
{
    public class PostViewModelServiceTests
    {
        private readonly IPostViewModelService _postViewModelService;

        public PostViewModelServiceTests()
        {
            var mockRepository = new Mock<IRepository<Post>>();
            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    Content = @"It is a truth universally acknowledged, that a single man in possession of a good fortune,
                        must be in want of a wife.",
                    Author = "Jane Austen",
                    CreatedOn = new DateTime(1813, 1, 28, 2, 0, 0)
                },
                new Post
                {
                    Id = 2,
                    Title = "Moby-Dick",
                    Content = "Call me Ishmael.",
                    Author = "Herman Melville",
                    CreatedOn = new DateTime(1854, 11, 14, 16, 30, 0)
                },
                new Post
                {
                    Id = 3,
                    Title = "The Last of the Mohicans",
                    Content = @"It was a feature peculiar to the colonial wars of North America, that the toils and dangers
                    of the wilderness were to be encountered before the adverse hosts could meet.",
                    Author = "James Fenimore Cooper",
                    CreatedOn = new DateTime(1826, 2, 4, 12, 0, 0)
                }
            });

            _postViewModelService = new PostViewModelService(mockRepository.Object);
        }

        [Fact]
        public async void GetRecentPostsShouldHaveNewestPostsFirst()
        {
            var posts = await _postViewModelService.GetRecentPostsAsync();

            posts.Should().BeInDescendingOrder(p => p.CreatedOn);
        }
    }
}