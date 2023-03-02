using Market.Application.Interfaces;
using Market.Application.Products.Commands.CreateProduct;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Commands.CreateType
{
    public class CreateTypeCommandHandler
         : IRequestHandler<CreateTypeCommand, int>
    {
        private readonly IMarketDbContext _dbContext;

        public CreateTypeCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<int> Handle(CreateTypeCommand request,
            CancellationToken cancellationToken)
        {
            var type = new TypeOfProduct
            {
               
                Name = request.Name,
                
            };

            await _dbContext.Types.AddAsync(type, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return type.Id;
        }
    }
}
