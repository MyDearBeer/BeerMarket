﻿using Market.Application.Common.Exeptions;
using Market.Application.Interfaces;
using Market.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Basket.AddProduct
{
    public class AddProductCommandHandler
        : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IMarketDbContext _dbContext;
        public AddProductCommandHandler(IMarketDbContext dbContext) =>
           _dbContext = dbContext;
        public async Task<Guid> Handle(AddProductCommand request,
            CancellationToken cancellationToken)
        {

            if (await _dbContext.BasketProducts.FirstOrDefaultAsync(b => 
            b.ProductId==request.ProductId&& b.UserId == request.UserId) !=null) 
            {
                throw new Exception();
            }
            var basketProduct = new BasketProduct
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
            };

          

            await _dbContext.BasketProducts.AddAsync(basketProduct, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return basketProduct.Id;
        }
    }
}
