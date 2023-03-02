using AutoMapper;
using Market.Application.Common.Exeptions;
using Market.Application.Interfaces;
using Market.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductDetails
{

        public class GetProductDetailsQueryHandler
            : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
        {
            private readonly IMarketDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetProductDetailsQueryHandler(IMarketDbContext dbContext,
                IMapper mapper) =>
                (_dbContext, _mapper) = (dbContext, mapper);
      public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request,
                CancellationToken cancellationToken)
            {
           
                var entity = await _dbContext.Products
                    .FirstOrDefaultAsync(product =>
                product.Id == request.Id, cancellationToken);

                TypeOfProduct type = await _dbContext.Types
                    .FirstOrDefaultAsync(type =>
                type.Id == entity.TypeId, cancellationToken);

            Factory factory = await _dbContext.Factories
                    .FirstOrDefaultAsync(factory =>
                factory.Id == entity.FactoryId, cancellationToken);

            List<ProductInfo> info = await _dbContext.ProductInfos
                    .Where(info =>
                info.ProductId == entity.Id).ToListAsync(cancellationToken);

            entity.Type = type;
            entity.Factory = factory;
            entity.Info = info;

            if (entity == null)
                {
                    throw new NotFoundExсeption(nameof(Product), request.Id);
                }

                return _mapper.Map<ProductDetailsVm>(entity);
            }
        }
}
