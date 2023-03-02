using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using Market.Application.Products.Queries.GetProductList;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Domain;

namespace Market.Application.CQRS.Queries.Products.GetBasketProductList
{
    public class GetBasketProductListQueryHandler
        : IRequestHandler<GetBasketProductListQuery, BasketProductListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBasketProductListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<BasketProductListVm> Handle
            (GetBasketProductListQuery request, CancellationToken cancellationToken)
        {
            var basketQuery = await _dbContext.BasketProducts
                .Where(bp => bp.UserId == request.UserId)
                .ProjectTo<BasketProductListDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            foreach(var product in basketQuery)
            {
                product.Product = await _dbContext.Products
                   .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync(bp => bp.Id == product.ProductId);
                    
            }

            return new BasketProductListVm { BasketProducts = basketQuery };
        }
    }
}
