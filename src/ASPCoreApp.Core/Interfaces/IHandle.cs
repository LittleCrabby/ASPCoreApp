using ASPCoreApp.Core.SharedKernel;

namespace ASPCoreApp.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}