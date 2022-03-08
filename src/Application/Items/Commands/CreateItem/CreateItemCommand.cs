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
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; }
        public int PersonItemId { get; set; }
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
                Name = request.Name,
                Price = request.Price,
                Notes = request.Notes,
                PersonItemId = request.PersonItemId,
            };

            _context.Items.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
