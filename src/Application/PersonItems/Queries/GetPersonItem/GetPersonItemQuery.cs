using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryManagementSystem.Application.Common.Interfaces;
using InventoryManagementSystem.Application.Common.Mappings;
using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.PersonItems.Queries.GetPersonItem
{
    public class GetPersonItemQuery : IRequest<PersonItemDto>
    {
        public int Id { get; set; }

    }

    public class GetPersonItemQueryHandler : IRequestHandler<GetPersonItemQuery, PersonItemDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonItemQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PersonItemDto> Handle(GetPersonItemQuery request, CancellationToken cancellationToken)
        {
            return await _context.PersonItems
                .Where(d => d.Id == request.Id)
                .ProjectTo<PersonItemDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
