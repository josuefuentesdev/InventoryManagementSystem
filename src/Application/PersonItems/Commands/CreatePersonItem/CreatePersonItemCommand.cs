using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.PersonItems.Commands.CreatePersonItem
{
    public class CreatePersonItemCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }

    }

    public class CreatePersonItemCommandHandler : IRequestHandler<CreatePersonItemCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePersonItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePersonItemCommand request, CancellationToken cancellationToken)
            {
            RegionInfo regionInfo = null;
            if (request.Region != null)
            {
                try
                {
                    regionInfo = new RegionInfo(request.Region);
                }
                catch (Exception)
                {
                    // TODO fluentValidation
                }
            }

            var entity = new PersonItem
            {
                Name = request.Name,
                LastName = request.LastName,
                Region = regionInfo?.Name,
            };

            _context.PersonItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
