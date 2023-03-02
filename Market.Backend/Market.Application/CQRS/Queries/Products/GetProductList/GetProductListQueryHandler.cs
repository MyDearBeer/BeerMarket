using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using Market.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Market.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler
        :IRequestHandler<GetProductListQuery,ProductListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ProductListVm> Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {

            IList<ProductLookupDto> productsQuery = new List<ProductLookupDto>();

            if (request.TypeId != null && request.FactoryId == null)
            
                productsQuery = await _dbContext.Products.Where(product =>
                product.TypeId == request.TypeId)
              .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);
            

            if (request.TypeId == null && request.FactoryId != null)
            
                productsQuery = await _dbContext.Products.Where(product =>
                product.FactoryId == request.FactoryId)
              .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);
            

            if (request.TypeId == null && request.FactoryId == null)
                productsQuery = await _dbContext.Products
             .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

            if (request.TypeId != null && request.FactoryId != null)
               productsQuery = await _dbContext.Products.Where(product =>
               product.FactoryId == request.FactoryId
               && product.TypeId == request.TypeId)
               .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
            if (request.Page != null && request.Limit != null)
            {
                int? offset = request.Page * request.Limit - request.Limit;

                return new ProductListVm { Products = productsQuery.Skip((int)offset).Take((int)request.Limit) };
            }
            else
                return new ProductListVm { Products = productsQuery };
        }
    }
}
