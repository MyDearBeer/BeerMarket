using AutoMapper;
using Market.Application.CQRS.Commands.Types.UpdateType;
using Market.Application.Products.Commands.CreateType;
using Market.Application.Products.Commands.DeleteType;
using Market.Application.Products.Commands.UpdateProduct;
using Market.Application.Products.Queries.GetTypeList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TypeController : BaseController
    {
       

       
        [HttpGet]
       
        public async Task<ActionResult<TypeListVm>> GetAll()
        {
            var query = new GetTypeListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<int>> Create(
            [FromBody] CreateTypeCommand createType)
        {
            var command = new CreateTypeCommand()
            {
                Name=createType.Name
            };
            // command.UserId = UserId;
            var typeId = await Mediator.Send(command);
            return Ok(typeId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update([FromBody] UpdateTypeCommand updateType)
        {
            //var command = _mapper.Map<UpdateProductCommand>(updateProductDto);

            var command = new UpdateTypeCommand()
            {
                Id = updateType.Id,
                Name = updateType.Name,
               
            };

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTypeCommand
            {
                Id = id,

            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
