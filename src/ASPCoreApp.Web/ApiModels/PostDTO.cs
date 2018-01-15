using System.Collections.Generic;
using ASPCoreApp.Core.Entities;

namespace ASPCoreApp.Web.ApiModels
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; private set; }
        public List<Comment> Comments { get; set; }

        public static PostDTO FromPost(Post item)
        {
            return new PostDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Body = item.Body,
                AuthorId = item.AuthorId,
                Comments = item.Comments
            };
        }
    }
}
