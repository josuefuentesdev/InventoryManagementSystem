using InventoryManagementSystem.Application.Common.Mappings;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.CategoryItems.Queries.GetCategoryItems
{
    public class CategoryItemDto : IMapFrom<CategoryItem>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
