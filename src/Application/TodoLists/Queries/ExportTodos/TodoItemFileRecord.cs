using InventoryManagementSystem.Application.Common.Mappings;
using InventoryManagementSystem.Domain.Entities;

namespace InventoryManagementSystem.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
