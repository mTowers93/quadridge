using Quadridge2.Models;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Quadridge2.ViewModels.Clients
{
    public class ClientFormViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public Client Client { get; set; }
    }
}