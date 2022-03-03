using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Items.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new Item
            {
                Title = request.Title,
            };

            _context.Items.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
