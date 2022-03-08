using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Mappings;
using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.Items.Queries.GetItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.Items.Queries.GetItemsWithPagination
{
    public class GetItemsWithPaginationQuery : IRequest<PaginatedList<ItemDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetItemsWithPaginationQueryHandler : IRequestHandler<GetItemsWithPaginationQuery, PaginatedList<ItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ItemDto>> Handle(GetItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Items
                .OrderBy(x => x.Name)
                .ProjectTo<ItemDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
