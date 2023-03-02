using MediatR;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Application.Interfaces;
using Market.Application.CQRS.Commands.CreateProduct;

namespace Market.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler
        :IRequestHandler<CreateProductCommand,Guid>
    {

        private readonly IMarketDbContext _dbContext;

        public CreateProductCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id=Guid.NewGuid(),
                Name = request.Name,
                Rating = request.Rating,
                Price = request.Price,
                Img = request.Img,
                FactoryId = request.FactoryId,
                TypeId = request.TypeId,
                Description = request.Description,
                Info = request.Info,
               
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            foreach (var info in request.Info)
            {
                info.Id = Guid.NewGuid();
                info.ProductId = product.Id;
                await _dbContext.ProductInfos.AddAsync(info, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
