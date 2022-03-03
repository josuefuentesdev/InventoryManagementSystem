using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.CategoryItems.Queries.GetCategoryItems
{
    public class GetCategoryItemsQuery : IRequest<List<CategoryItemDto>>
    {
    }

    public class GetCategoryItemsQueryHandler : IRequestHandler<GetCategoryItemsQuery, List<CategoryItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryItemDto>> Handle(GetCategoryItemsQuery request, CancellationToken cancellationToken)
        {
            return await _context.CategoryItems
                .ProjectTo<CategoryItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

        }

    }
}
