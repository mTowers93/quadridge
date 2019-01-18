using Quadridge2.Models;
using Quadridge2.Models.Deals;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels
{
    public class TrustFormViewModel
    {
        public Trust Trust { get; set; }
        public ICollection<Structure> Structures { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}