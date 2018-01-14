using ASPCoreApp.Core.SharedKernel;
using System.Collections.Generic;

namespace ASPCoreApp.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } 
        public string Body { get; set; }
        public int AuthorId { get; set; }

        public List<Comment> Comments { get; set; }
    }
}