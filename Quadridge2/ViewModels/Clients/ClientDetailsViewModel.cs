using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Deals;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Quadridge2.ViewModels.Clients
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<StructureComment> Comments { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Deal> Deals { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}