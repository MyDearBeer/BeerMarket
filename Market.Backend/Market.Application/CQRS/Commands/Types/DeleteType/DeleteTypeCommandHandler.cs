using Market.Application.Common.Exeptions;
using Market.Application.Interfaces;
using Market.Application.Products.Commands.DeleteProduct;
using Market.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Commands.DeleteType
{
    public class DeleteTypeCommandHandler
        : IRequestHandler<DeleteTypeCommand>
    {
        private readonly IMarketDbContext _dbContext;

        public DeleteTypeCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Types
                .FirstOrDefaultAsync(type =>
            type.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundExсeption(nameof(TypeOfProduct), 
                    request.Id);
            }

            _dbContext.Types.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
