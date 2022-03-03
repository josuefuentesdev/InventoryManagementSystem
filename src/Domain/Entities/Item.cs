using InventoryManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    public class Item : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
