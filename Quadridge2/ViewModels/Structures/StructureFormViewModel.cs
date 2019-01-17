using Quadridge2.Models.Deals;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.Structures
{
    public class StructureFormViewModel
    {
        public Structure Structure { get; set; }
        public IEnumerable<StructureCategory> StructureCategories { get; set; }
        public IEnumerable<Contact> Contacts { get; set; } 
    }
}