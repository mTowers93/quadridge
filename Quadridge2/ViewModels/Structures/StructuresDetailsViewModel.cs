using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.Structures
{
    public class StructuresDetailsViewModel
    {
        public virtual Structure Structure { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Trust> Trusts { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}