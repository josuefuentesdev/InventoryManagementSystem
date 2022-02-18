using InventoryManagementSystem.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace InventoryManagementSystem.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
