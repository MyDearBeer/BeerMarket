using Market.Application.CQRS.Commands.Factories.CreateFactory;
using Market.Application.Interfaces;
using Market.Application.Products.Commands.CreateType;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.CreateFactory
{
    public class CreateFactoryCommandHandler
     : IRequestHandler<CreateFactoryCommand, int>
    {
        private readonly IMarketDbContext _dbContext;

        public CreateFactoryCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<int> Handle(CreateFactoryCommand request,
            CancellationToken cancellationToken)
        {
            var factory = new Factory
            {

                Name = request.Name,
                Address = request.Address,
                Img = request.Img,

            };

            await _dbContext.Factories.AddAsync(factory, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return factory.Id;
        }
    }
}
