using System;
using System.Collections.Generic;
using Quadridge2.Models.Deals;
using Quadridge2.Models.Contacts;
using Quadridge2.Models;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels
{
    public class OtherInstitutionDetailViewModel
    {
        public Institute OtherInstitution { get; set; }
        public ICollection<Structure> Structures { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}