using Market.Application.Common.Exeptions;
using Market.Application.CQRS.Commands.Types.UpdateType;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.UpdateFactory
{
    public class UpdateFactoryCommandHandler
    : IRequestHandler<UpdateFactoryCommand>
    {
        private readonly IMarketDbContext _dbContext;

        public UpdateFactoryCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateFactoryCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Factories
                .FirstOrDefaultAsync(factory =>
            factory.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundExсeption(nameof(Type), request.Id);
            }
            entity.Name = request.Name;
            entity.Address = request.Address;
            entity.Img = request.Img;



            await _dbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
