using ASPCoreApp.Core.SharedKernel;

namespace ASPCoreApp.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Body { get; set; }
        public int AuthorId { get; set; }
                public int PostId { get; set; }
        public Post Post { get; set; }
    }
}