using InventoryManagementSystem.Domain.Common;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
