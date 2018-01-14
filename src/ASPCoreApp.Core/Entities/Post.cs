using ASPCoreApp.Core.SharedKernel;

namespace ASPCoreApp.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } 
        public string Body { get; set; }
        public int AuthorId { get; private set; }
    }
}