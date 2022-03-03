using InventoryManagementSystem.Application.Common.Models;
using InventoryManagementSystem.Application.CategoryItems.Commands.CreateCategoryItem;
using InventoryManagementSystem.Application.CategoryItems.Commands.DeleteCategoryItem;
using InventoryManagementSystem.Application.CategoryItems.Commands.UpdateCategoryItem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using InventoryManagementSystem.Domain.Entities;
using InventoryManagementSystem.Application.CategoryItems.Queries.GetCategoryItems;

namespace InventoryManagementSystem.WebUI.Controllers
{
    //[Authorize]
    public class CategoryItemsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CategoryItemDto>> GetCategoryItems()
        {
            return await Mediator.Send(new GetCategoryItemsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCategoryItemCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCategoryItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        //[HttpPut("[action]")]
        //public async Task<ActionResult> UpdateItemDetails(int id, UpdateCategoryItemDetailCommand command)
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
            await Mediator.Send(new DeleteCategoryItemCommand { Id = id });

            return NoContent();
        }
    }
}
