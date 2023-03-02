using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using Market.Application.Products.Queries.GetProductList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetTypeList
{
    public class GetTypeListQueryHandler
        : IRequestHandler<GetTypeListQuery,TypeListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTypeListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<TypeListVm> Handle(GetTypeListQuery request,
            CancellationToken cancellationToken)
        {

            var typesQuery = await _dbContext.Types
                .ProjectTo<TypeListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return new TypeListVm { Types = typesQuery };
        }
    }
}
