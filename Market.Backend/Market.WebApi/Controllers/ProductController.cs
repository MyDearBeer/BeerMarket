using AutoMapper;
using Market.Application.CQRS.Commands.CreateProduct;
using Market.Application.Products.Commands.CreateProduct;
using Market.Application.Products.Commands.CreateType;
using Market.Application.Products.Commands.DeleteProduct;
using Market.Application.Products.Commands.UpdateProduct;
using Market.Application.Products.Queries.GetProductDetails;
using Market.Application.Products.Queries.GetProductList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Market.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment env;

        public ProductController(IMapper mapper,
            IWebHostEnvironment env)
        {
            _mapper = mapper;
            this.env = env;
        }


        [HttpGet()]
      
        public async Task<ActionResult<ProductListVm>> GetAll(int? typeId, 
            int? factoryId, int? page,int? limit)
        {
            var query = new GetProductListQuery
            {
                FactoryId = factoryId,
                TypeId=typeId,
                Page = page,
                Limit = limit
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductListVm>> Get(Guid Id)
        {
            var query = new GetProductDetailsQuery
            {
                Id = Id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]

        public async Task<ActionResult<Guid>> Create(
            [FromBody] CreateProductCommand createProduct)
        {
            // var command = _mapper.Map<CreateProductCommand>(createProductDto);
            var command = new CreateProductCommand()
            {
                Name =createProduct.Name,
                Price = createProduct.Price,
                Img = createProduct.Img,
                Rating = createProduct.Rating,
                FactoryId = createProduct.FactoryId,
                TypeId= createProduct.TypeId,
                Description= createProduct.Description,
                Info = createProduct.Info
            };

            // command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProduct)
        {
            //var command = _mapper.Map<UpdateProductCommand>(updateProductDto);

            var command = new UpdateProductCommand()
            {
                Id = updateProduct.Id,
                Name = updateProduct.Name,
                Price = updateProduct.Price,
                Img = updateProduct.Img,
                Rating = updateProduct.Rating,
                FactoryId = updateProduct.FactoryId,
                TypeId = updateProduct.TypeId,
                Description = updateProduct.Description,
                Info= updateProduct.Info
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var command = new DeleteProductCommand
            {
                Id = Id,
                
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [Route("SaveFile")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = env.ContentRootPath + "/Photos/" + filename;
                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound(new { message = "Trouble" });


            }

        }
    }
}
