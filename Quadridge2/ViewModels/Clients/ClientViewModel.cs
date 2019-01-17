using Quadridge2.Models;
using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.Clients
{
    public class ClientViewModel
    {
        public IEnumerable<Entity> Entities { get; set; }
        public IEnumerable<Trust> Trusts { get; set; }
        public IEnumerable<Structure> Structures { get; set; }
    }
}