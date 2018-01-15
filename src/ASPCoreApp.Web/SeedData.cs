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

            Post[] newPosts =
            {
                new Post()
                {
                    Title = "Post 1",
                    Body = "Sample text for post 1",
                    AuthorId = 1
                },
                new Post()
                {
                    Title = "Post 2",
                    Body = "Sample text for post 2",
                    AuthorId = 2
                },
                new Post()
                {
                    Title = "Post 3",
                    Body = "Sample text for post 3",
                    AuthorId = 3
                }
            };

            IList<Comment> newComments = new List<Comment>()
            {
                new Comment()
                {
                    Body = "Comment 1 to Post 1",
                    AuthorId = 2,
                    Post = newPosts[0]
                },
                new Comment()
                {
                    Body = "Comment 2 to Post 1",
                    AuthorId = 3,
                    Post = newPosts[0]
                },
                new Comment()
                {
                    Body = "Comment 1 to Post 2",
                    AuthorId = 4,
                    Post = newPosts[1]
                },
                new Comment()
                {
                    Body = "Comment 2 to Post 2",
                    AuthorId = 1,
                    Post = newPosts[1]
                },
                new Comment()
                {
                    Body = "Comment 1 to Post 3",
                    AuthorId = 3,
                    Post = newPosts[2]
                },
                new Comment()
                {
                    Body = "Comment 2 to Post 3",
                    AuthorId = 5,
                    Post = newPosts[2]
                }
            };

            dbContext.Comments.AddRange(newComments);

            dbContext.SaveChanges();
        }

    }
}
