using Quadridge2.Models;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels
{
    public class InteractionsFormViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<InteractionType> InteractionTypes { get; set; }
        public Interaction Interaction { get; set; }
    }
}