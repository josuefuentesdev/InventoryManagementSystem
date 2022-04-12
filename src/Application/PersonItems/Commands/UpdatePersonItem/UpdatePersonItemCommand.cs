using InventoryManagementSystem.Application.Common.Exceptions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.PersonItems.Commands.UpdatePersonItem
{
    public class UpdatePersonItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Region { get; set; }


    }

    public class UpdatePersonItemCommandHandler : IRequestHandler<UpdatePersonItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePersonItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePersonItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PersonItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PersonItem), request.Id);
            }

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

            entity.Name = request.Name;
            entity.LastName = request.LastName;
            if (request?.Region != null)
            {
                entity.Region = request.Region;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
