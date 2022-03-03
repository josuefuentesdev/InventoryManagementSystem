using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Items.Queries.GetItem
{
    public class GetItemQuery : IRequest<ItemDto>
    {
        public int Id { get; set; }

    }

    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            return await _context.Items
                .Where(d => d.Id == request.Id)
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
