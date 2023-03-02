using Market.Application.Common.Exeptions;
using Market.Application.Interfaces;
using Market.Application.Products.Commands.UpdateProduct;
using Market.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Types.UpdateType
{
    public class UpdateTypeCommandHandler
      : IRequestHandler<UpdateTypeCommand>
    {
        private readonly IMarketDbContext _dbContext;

        public UpdateTypeCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateTypeCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Types
                .FirstOrDefaultAsync(type =>
            type.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundExсeption(nameof(Type), request.Id);
            }
            entity.Name = request.Name;
          

            await _dbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
