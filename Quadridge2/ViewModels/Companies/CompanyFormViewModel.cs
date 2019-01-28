using Quadridge2.Models;
using Quadridge2.Models.Maintenance;
using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.Companies
{
    public class CompanyFormViewModel
    {
        public Company Company { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Trust> Trusts { get; set; }
        public IEnumerable<FeeType> FeeTypes { get; set; }
        public IEnumerable<BillingBasis> BillingBases { get; set; }
        public IEnumerable<Structure> Structures { get; set; }
    }
}