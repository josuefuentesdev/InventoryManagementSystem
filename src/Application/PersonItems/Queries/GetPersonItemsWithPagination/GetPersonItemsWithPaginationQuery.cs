using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Mappings;
using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.PersonItems.Queries.GetPersonItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.PersonItems.Queries.GetPersonItemsWithPagination
{
    public class GetPersonItemsWithPaginationQuery : IRequest<PaginatedList<PersonItemDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetPersonItemsWithPaginationQueryHandler : IRequestHandler<GetPersonItemsWithPaginationQuery, PaginatedList<PersonItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PersonItemDto>> Handle(GetPersonItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.PersonItems
                .OrderByDescending(x => x.Created)
                .ProjectTo<PersonItemDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
