using InventoryManagementSystem.Application.Common.Interfaces;
using System;

namespace InventoryManagementSystem.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
