using System;

namespace ASPCoreApp.Core.SharedKernel
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}