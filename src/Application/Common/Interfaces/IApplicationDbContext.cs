using InventoryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<PersonItem> PersonItems { get; set; }

        DbSet<CategoryItem> CategoryItems { get; set; }

        DbSet<Item> Items { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
