using InventoryManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Item : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; }

        public PersonItem PersonItem { get; set; }
        public int PersonItemId { get; set; }

    }
}
