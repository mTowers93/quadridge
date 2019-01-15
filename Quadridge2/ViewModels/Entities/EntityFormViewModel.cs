using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;

namespace Quadridge2.ViewModels.Entities
{
    public class EntityFormViewModel
    {
        public Entity Entity { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Trust> Trusts { get; set; }
        public IEnumerable<FeeType> FeeTypes { get; set; }
        public IEnumerable<BillingBasis> BillingBases { get; set; }
        public IEnumerable<Structure> Structures { get; set; }
    }
}