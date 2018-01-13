using ASPCoreApp.Core.Events;
using ASPCoreApp.Core.Interfaces;

namespace ASPCoreApp.Core.Services
{
    public class ToDoItemService : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            // Do Nothing
        }
    }
}
