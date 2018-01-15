using ASPCoreApp.Core.Entities;
using ASPCoreApp.Infrastructure.Data;
using System.Collections.Generic;

namespace ASPCoreApp.Web
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            var Posts = dbContext.Posts;
            foreach (var item in Posts)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();

            var Post1 = new Post()
            {
                Title = "Post 1",
                Body = "Sample text for post 1",
                AuthorId = 1
            };

            var Post2 = new Post()
            {
                Title = "Post 2",
                Body = "Sample text for post 2",
                AuthorId = 2
            };

            IList<Comment> newComments = new List<Comment>()
            {
                new Comment()
                {
                    Body = "Comment 1 to Post 1",
                    AuthorId = 2,
                    Post = Post1
                },
                new Comment()
                {
                    Body = "Comment 2 to Post 1",
                    AuthorId = 3,
                    Post = Post1
                },
                new Comment()
                {
                    Body = "Comment 3 to Post 1",
                    AuthorId = 4,
                    Post = Post1
                },
                new Comment()
                {
                    Body = "Comment 1 to Post 2",
                    AuthorId = 1,
                    Post = Post2
                },
                new Comment()
                {
                    Body = "Comment 2 to Post 2",
                    AuthorId = 3,
                    Post = Post2
                },
                new Comment()
                {
                    Body = "Comment 3 to Post 2",
                    AuthorId = 5,
                    Post = Post2
                }
            };

            dbContext.Comments.AddRange(newComments);

            dbContext.SaveChanges();
        }

    }
}
