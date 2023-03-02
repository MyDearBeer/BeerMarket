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

namespace Market.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMarketDbContext _dbContext;

        public UpdateProductCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products
                .FirstOrDefaultAsync(product =>
            product.Id == request.Id, cancellationToken);

            var entityInfo = await _dbContext.ProductInfos
                .Where(info =>
                info.ProductId == request.Id).ToListAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundExсeption(nameof(Product), request.Id);
            }
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.Rating = request.Rating;
            entity.Img = request.Img;
            entity.FactoryId = request.FactoryId;
            entity.TypeId = request.TypeId;
            entity.Info = request.Info;
            entityInfo = (List<ProductInfo>)request.Info;
         
            await _dbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
