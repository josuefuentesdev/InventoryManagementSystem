using AutoMapper;
using InventoryManagementSystem.Application.Common.Mappings;
using InventoryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Application.PersonItems.Queries.GetPersonItem
{
    public class PersonItemDto : IMapFrom<PersonItem>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public string Region { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<TodoItem, PersonItemDto>()
        //        //.ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
        //}
    }
}
