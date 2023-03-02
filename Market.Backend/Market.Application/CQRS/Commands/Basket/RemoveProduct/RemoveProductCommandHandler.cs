using Market.Application.Common.Exeptions;
using Market.Application.Interfaces;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Basket.RemoveProduct
{
    public class RemoveProductCommandHandler
   : IRequestHandler<RemoveProductCommand>
    {
        private readonly IMarketDbContext _dbContext;

        public RemoveProductCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(RemoveProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.BasketProducts
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExсeption(nameof(BasketProduct),
                    request.Id);
            }

            _dbContext.BasketProducts.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
