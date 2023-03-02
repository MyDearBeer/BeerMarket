using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using Market.Application.Products.Queries.GetTypeList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Factories.GetFactoryList
{
    public class GetFactoryListQueryHandler
        : IRequestHandler<GetFactoryListQuery, FactoryListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFactoryListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<FactoryListVm> Handle(GetFactoryListQuery request,
            CancellationToken cancellationToken)
        {

            var factoriesQuery = await _dbContext.Factories
                .ProjectTo<FactoryListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return new FactoryListVm { Factories = factoriesQuery };
        }
    }
}
