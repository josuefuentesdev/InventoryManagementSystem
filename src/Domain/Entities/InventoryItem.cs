using InventoryManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    //public class InventoryItem : AuditableEntity, IHasDomainEvent
    public class InventoryItem : AuditableEntity
    {
        public int Id { get; set; }

        //public TodoList List { get; set; }

        //public int ListId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        //public PriorityLevel Priority { get; set; }

        //public DateTime? Reminder { get; set; }

        //private bool _done;
        //public bool Done
        //{
        //    get => _done;
        //    set
        //    {
        //        if (value == true && _done == false)
        //        {
        //            DomainEvents.Add(new TodoItemCompletedEvent(this));
        //        }

        //        _done = value;
        //    }
        //}

        //public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
