using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.AppFiles.Commands.CreateAppFiles
{
    public class CreateAppFileCommand : IRequest<int>
    {
        public byte[] Content { get; set; }

    }
    public class CreateAppFileCommandHandler : IRequestHandler<CreateAppFileCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAppFileCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAppFileCommand request, CancellationToken cancellationToken)
        {

            var entity = new AppFile
            {
                Content = request.Content,
                Size = request.Content.Length,
            };

            _context.AppFiles.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
