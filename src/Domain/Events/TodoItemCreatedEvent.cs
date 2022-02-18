using InventoryManagementSystem.Domain.Common;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
