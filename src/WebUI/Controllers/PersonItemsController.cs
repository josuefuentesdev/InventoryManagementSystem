using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.PersonItems.Commands.CreatePersonItem;
using InventoryManagementSystem.Application.PersonItems.Commands.DeletePersonItem;
using InventoryManagementSystem.Application.PersonItems.Commands.UpdatePersonItem;
using InventoryManagementSystem.Application.PersonItems.Queries.GetPersonItem;
using InventoryManagementSystem.Application.PersonItems.Queries.GetPersonItemsWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagementSystem.WebUI.Controllers
{
    //[Authorize]
    public class PersonItemsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<PersonItemDto>>> GetPersonItemsWithPagination([FromQuery] GetPersonItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
        [HttpGet("{id}")]
        public async Task<PersonItemDto> Get(int id)
        {
            return await Mediator.Send(new GetPersonItemQuery() { Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePersonItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdatePersonItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        //[HttpPut("[action]")]
        //public async Task<ActionResult> UpdateItemDetails(int id, UpdatePersonItemDetailCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePersonItemCommand { Id = id });

            return NoContent();
        }
    }
}
