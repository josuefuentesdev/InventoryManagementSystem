//using InventoryManagementSystem.Application.Common.Interfaces;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InventoryManagementSystem.Application.AppFiles.Queries
//{
//    public class GetAppFileQuery
//    {

//    }

//    public class GetAppFileQueryHandler : IRequestHandler<GetAppFileQuery, AppFileDto>
//    {
//        private readonly IApplicationDbContext _context;
//        private readonly IMapper _mapper;

//        public GetAppFileQueryHandler(IApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<AppFileDto> Handle(GetAppFileQuery request, CancellationToken cancellationToken)
//        {
//            return await _context.AppFiles
//                .Where(d => d.Id == request.Id)
//                .ProjectTo<AppFileDto>(_mapper.ConfigurationProvider)
//                .FirstOrDefaultAsync();
//        }
//    }
//}
