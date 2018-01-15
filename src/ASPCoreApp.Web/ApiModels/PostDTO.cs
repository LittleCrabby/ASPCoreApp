using System;
using System.Collections.Generic;
using ASPCoreApp.Core.Entities;

namespace ASPCoreApp.Web.ApiModels
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuthorId { get; private set; }
        public List<CommentDTO> Comments { get; set; }

        public static PostDTO FromPost(Post item)
        {
            return new PostDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Body = item.Body,
                AuthorId = item.AuthorId,
                DateCreated = item.DateCreated,
                Comments = CommentDTO.FromComments(item.Comments)
            };
        }
    }
}
