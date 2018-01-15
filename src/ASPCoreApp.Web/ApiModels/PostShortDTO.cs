using ASPCoreApp.Core.Entities;

namespace ASPCoreApp.Web.ApiModels
{
    public class PostShortDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public static PostShortDTO ShortPost(Post item)
        {
            return new PostShortDTO()
            {
                Id = item.Id,
                Title = item.Title,
            };
        }
    }
}
