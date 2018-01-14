using System.ComponentModel.DataAnnotations;
using ASPCoreApp.Core.Entities;

namespace ASPCoreApp.Web.ApiModels
{
    public class PostDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; private set; }

        public static PostDTO FromPost(Post item)
        {
            return new PostDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Body,
                AuthorId = item.AuthorId,
            };
        }
    }
}
