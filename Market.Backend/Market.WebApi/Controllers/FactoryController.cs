using Market.Application.CQRS.Commands.Factories.CreateFactory;
using Market.Application.CQRS.Commands.Factories.DeleteFactory;
using Market.Application.CQRS.Commands.Factories.UpdateFactory;
using Market.Application.CQRS.Commands.Types.UpdateType;
using Market.Application.CQRS.Queries.Factories.GetFactoryList;
using Market.Application.Products.Commands.CreateType;
using Market.Application.Products.Commands.DeleteType;
using Market.Application.Products.Queries.GetTypeList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Market.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FactoryController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<FactoryListVm>> GetAll()
        {
            var query = new GetFactoryListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<int>> Create(
            [FromBody] CreateFactoryCommand createFactory)
        {
            var command = new CreateFactoryCommand()
            {
                Name = createFactory.Name,
                Address = createFactory.Address,
                Img = createFactory.Img,
            };
            // command.UserId = UserId;
            var factoryId = await Mediator.Send(command);
            return Ok(factoryId);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update([FromBody] UpdateFactoryCommand updateFactory)
        {
            //var command = _mapper.Map<UpdateProductCommand>(updateProductDto);

            var command = new UpdateFactoryCommand()
            {
                Id = updateFactory.Id,
                Name = updateFactory.Name,
                Address = updateFactory.Address,
                Img= updateFactory.Img,
                

            };

            await Mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFactoryCommand
            {
                Id = id,

            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
