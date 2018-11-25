using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;

namespace Quadridge2.ViewModels
{
    public class ClientFormViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public Client Client { get; set; }
    }
}