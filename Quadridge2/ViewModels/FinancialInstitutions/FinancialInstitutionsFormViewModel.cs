using Quadridge2.Models.Maintenance;
using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.FinancialInstitutions
{
    public class FinancialInstitutionsFormViewModel
    {
        public FinancialInstitution FinancialInstitution { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}