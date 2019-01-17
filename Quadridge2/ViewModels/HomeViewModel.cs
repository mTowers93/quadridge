using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Quadridge2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Interaction> Interactions { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Deal> Deals { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}