using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.Trusts
{
    public class TrustDetailsViewModel
    {
        public Trust Trust { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}