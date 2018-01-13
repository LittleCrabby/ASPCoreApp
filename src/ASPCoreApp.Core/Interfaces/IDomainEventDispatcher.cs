using ASPCoreApp.Core.SharedKernel;

namespace ASPCoreApp.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}