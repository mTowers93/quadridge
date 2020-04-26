using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.LawFirms
{
    public class LawFirmDetailsViewModel
    {
        public LawFirm LawFirm { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Structure> Structures { get; set; }
    }
}