using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
