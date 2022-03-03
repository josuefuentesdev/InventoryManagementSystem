using InventoryManagementSystem.Application.Common.Exceptions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.CategoryItems.Commands.DeleteCategoryItem
{
    public class DeleteCategoryItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryItemCommandHandler : IRequestHandler<DeleteCategoryItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CategoryItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CategoryItem), request.Id);
            }

            _context.CategoryItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
