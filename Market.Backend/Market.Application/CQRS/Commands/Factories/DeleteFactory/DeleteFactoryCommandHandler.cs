using Market.Application.Common.Exeptions;
using Market.Application.Interfaces;
using Market.Application.Products.Commands.DeleteType;
using Market.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.DeleteFactory
{
    public class DeleteFactoryCommandHandler
        : IRequestHandler<DeleteFactoryCommand>
    {
        private readonly IMarketDbContext _dbContext;

        public DeleteFactoryCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteFactoryCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Factories
                .FirstOrDefaultAsync(factory =>
            factory.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundExсeption(nameof(Factory),
                    request.Id);
            }

            _dbContext.Factories.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
