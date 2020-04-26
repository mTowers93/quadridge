using Quadridge2.Models.Contacts;
using Quadridge2.Models;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.Contacts
{
    public class ContactDetailsViewModel
    {
        public Contact Contact { get; set; }
        public Interaction Interaction { get; set; }
        public virtual ICollection<InteractionType> InteractionTypes { get; set; }
    }
}