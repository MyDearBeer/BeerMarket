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

namespace Market.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand>
    {
        private readonly IMarketDbContext _dbContext;

        public DeleteProductCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products
                .FirstOrDefaultAsync(product =>
            product.Id == request.Id, cancellationToken);

            //var entityInfo = await _dbContext.ProductInfos
            //   .Where(info =>
            //   info.ProductId == request.Id).ToListAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundExсeption(nameof(Product), request.Id);
            }

            _dbContext.Products.Remove(entity);
            //foreach (var info in entityInfo)
            //{
            //    _dbContext.ProductInfos.Remove(info);
            //        }

            await _dbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
