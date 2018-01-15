using System;
using System.Collections.Generic;
using ASPCoreApp.Core.Entities;

namespace ASPCoreApp.Web.ApiModels
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
        public DateTime? DateCreated { get; set; }

        public static List<CommentDTO> FromComments(IList<Comment> items)
        {
            var CommentsList = new List<CommentDTO>();
            foreach (var item in items)
            {
                CommentsList.Add(new CommentDTO()
                {
                    Id = item.Id,
                    Body = item.Body,
                    AuthorId = item.AuthorId,
                    DateCreated = item.DateCreated,
                });
            }

            return CommentsList;
        }
    }
}
