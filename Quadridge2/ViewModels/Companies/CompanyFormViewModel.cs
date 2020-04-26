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
        public List<ServiceCheckboxItem> Services { get; set; }
        public ICollection<Trust> Trusts { get; set; }
        public ICollection<FeeType> FeeTypes { get; set; }
        public ICollection<BillingBasis> BillingBases { get; set; }
        public ICollection<Structure> Structures { get; set; }

        public CompanyFormViewModel()
        {
            Services = new List<ServiceCheckboxItem>();
        }
    }
}