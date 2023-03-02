using AutoMapper;
using Market.Application.CQRS.Commands.Basket.AddProduct;
using Market.Application.CQRS.Commands.Basket.RemoveProduct;
using Market.Application.CQRS.Commands.CreateProduct;
using Market.Application.CQRS.Queries.Products.GetBasketProductList;
using Market.Application.Products.Commands.DeleteProduct;
using Market.Application.Products.Commands.UpdateProduct;
using Market.Application.Products.Queries.GetProductDetails;
using Market.Application.Products.Queries.GetProductList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Market.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : BaseController
    {
        private readonly IMapper _mapper;

        private Guid UserId =>
           Guid.Parse(User.Claims
               .Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public BasketController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<BasketProductListVm>> GetAll()
        {
            var query = new GetBasketProductListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        [HttpPost]
        [Authorize]
        // [Authorize (Roles = "Admin")]

        public async Task<ActionResult<Guid>> Create(
            [FromBody] AddProductCommand addProduct)
        {
            // var command = _mapper.Map<CreateProductCommand>(createProductDto);
            var command = new AddProductCommand()
            {
               ProductId = addProduct.ProductId,
               UserId = UserId
            };

            // command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpDelete("{id}")]
        [Authorize]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new RemoveProductCommand
            {
                Id = Id,
                UserId = UserId
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
