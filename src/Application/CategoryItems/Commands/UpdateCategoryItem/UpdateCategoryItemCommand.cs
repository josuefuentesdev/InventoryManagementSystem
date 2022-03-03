using InventoryManagementSystem.Application.Common.Exceptions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.CategoryItems.Commands.UpdateCategoryItem
{
    public class UpdateCategoryItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //public bool Done { get; set; }
    }

    public class UpdateCategoryItemCommandHandler : IRequestHandler<UpdateCategoryItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCategoryItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCategoryItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CategoryItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CategoryItem), request.Id);
            }

            entity.Title = request.Title;
            //entity.Done = request.Done;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
