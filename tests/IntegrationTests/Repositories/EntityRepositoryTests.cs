using System;
using System.Collections.Generic;
using Blog.Core.Entities;
using Blog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Blog.IntegrationTests.Repositories
{
    public class EntityRepositoryTests
    {
        private readonly BlogContext _blogContext;
        private readonly EntityRepository<Post> _entityRepository;

        public EntityRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _blogContext = new BlogContext(options);

            _entityRepository = new EntityRepository<Post>(_blogContext);
        }

        [Fact]
        public async void GetsEntityById()
        {
            var expected = new Post
            {
                Id = 1,
                Title = "Slaughterhouse-Five",
                Content = "All this happened, more or less.",
                Author = "Kurt Vonnegut"
            };
            _blogContext.Add<Post>(expected);
            _blogContext.SaveChanges();

            var actual = await _entityRepository.GetByIdAsync(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void GetsAll()
        {
            var expected = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    Content = @"It is a truth universally acknowledged, that a single man in possession of a good fortune,
                        must be in want of a wife.",
                    Author = "Jane Austen"
                },
                new Post
                {
                    Id = 2,
                    Title = "Moby-Dick",
                    Content = "Call me Ishmael.",
                    Author = "Herman Melville"
                }
            };
            _blogContext.AddRange(expected);
            _blogContext.SaveChanges();

            var actual = await _entityRepository.GetAllAsync();
            Assert.Equal(expected, actual);
        }
    }
}