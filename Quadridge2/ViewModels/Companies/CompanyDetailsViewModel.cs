using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.Companies
{
    public class CompanyDetailsViewModel
    {
        public Company Company { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}