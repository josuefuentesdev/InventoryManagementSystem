using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.Items.Commands.CreateItem;
using InventoryManagementSystem.Application.Items.Commands.DeleteItem;
using InventoryManagementSystem.Application.Items.Commands.UpdateItem;
using InventoryManagementSystem.Application.Items.Queries.GetItem;
using InventoryManagementSystem.Application.Items.Queries.GetItemsWithPagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.WebUI.Controllers
{
    public class ItemsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ItemDto>>> GetItemsWithPagination([FromQuery] GetItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }
        [HttpGet("{id}")]
        public async Task<ItemDto> Get(int id)
        {
            return await Mediator.Send(new GetItemQuery() { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        //[HttpPut("[action]")]
        //public async Task<ActionResult> UpdateItemDetails(int id, UpdateItemDetailCommand command)
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
            await Mediator.Send(new DeleteItemCommand { Id = id });

            return NoContent();
        }
    }
}
