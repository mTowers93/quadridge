using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;

namespace Quadridge2.ViewModels
{
    public class DealFormViewModel
    {
        public IEnumerable<DealType> Types { get; set; }
        public IEnumerable<Bank> Banks { get; set; }
        public IEnumerable<LawFirm> LawFirms { get; set; }

        public Deal Deal { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        public IEnumerable<Service> Services { get; set; }
    }
}