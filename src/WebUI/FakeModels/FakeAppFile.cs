using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.WebUI.FakeModels
{
    public class FakeAppFile
    {
        [BindNever]
        public IFormFile File { get; set; }

        public string CreatedBy { get; set; }
    }
}
