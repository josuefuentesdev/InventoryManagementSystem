using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.CategoryItems.Commands.CreateCategoryItem
{
    public class CreateCategoryItemCommand : IRequest<int>
    {
        //public int ListId { get; set; }

        public string Title { get; set; }
    }

    public class CreateCategoryItemsCommandHandler : IRequestHandler<CreateCategoryItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryItemsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCategoryItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new CategoryItem
            {
                Title = request.Title,
            };

            //entity.DomainEvents.Add(new CategoryItemCreatedEvent(entity));

            _context.CategoryItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
