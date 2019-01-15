using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;

namespace Quadridge2.ViewModels.Clients
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Deal> Deals { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}