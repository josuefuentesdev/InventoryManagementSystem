using InventoryManagementSystem.Application.Common.Exceptions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.PersonItems.Commands.DeletePersonItem
{
    public class DeletePersonItemCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePersonItemCommandHandler : IRequestHandler<DeletePersonItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePersonItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PersonItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PersonItem), request.Id);
            }

            _context.PersonItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
