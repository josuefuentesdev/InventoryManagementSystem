using InventoryManagementSystem.Application.Common.Exceptions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }

    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Items.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Item), request.Id);
            }

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
