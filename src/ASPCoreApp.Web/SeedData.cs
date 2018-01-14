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

            dbContext.Posts.Add(new Post()
            {
                Title = "Post 1",
                Body = "Sample text for post 1",
                AuthorId = 1,
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Body = "Comment 1 to Post 1",
                        AuthorId = 2
                    },
                    new Comment()
                    {
                        Body = "Comment 2 to Post 1",
                        AuthorId = 3
                    },
                    new Comment()
                    {
                        Body = "Comment 3 to Post 1",
                        AuthorId = 4
                    }
                }
            });
            dbContext.Posts.Add(new Post()
            {
                Title = "Post 2",
                Body = "Sample text for post 2",
                AuthorId = 2,
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Body = "Comment 1 to Post 2",
                        AuthorId = 1
                    },
                    new Comment()
                    {
                        Body = "Comment 2 to Post 2",
                        AuthorId = 3
                    },
                    new Comment()
                    {
                        Body = "Comment 3 to Post 2",
                        AuthorId = 5
                    }
                }
            });

            dbContext.SaveChanges();
        }

    }
}
