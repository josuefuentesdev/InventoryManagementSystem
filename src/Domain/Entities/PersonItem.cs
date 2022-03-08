using InventoryManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Entities
{
    //public class PersonItem : AuditableEntity, IHasDomainEvent
    public class PersonItem : AuditableEntity
    {
        public int Id { get; set; }

        //public TodoList List { get; set; }

        //public int ListId { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public IList<Item> Items { get; set; }

        //public string Note { get; set; }

        //public PriorityLevel Priority { get; set; }

        //public DateTime? Reminder { get; set; }

        //private bool _employed;
        //public bool Employed
        //{
        //    get => _employed;
        //    set
        //    {
        //        if (value == true && _employed == false)
        //        {
        //            DomainEvents.Add(new TodoItemCompletedEvent(this));
        //        }

        //        _employed = value;
        //    }
        //}

        //public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
