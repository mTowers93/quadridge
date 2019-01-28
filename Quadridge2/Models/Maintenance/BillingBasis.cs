using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Maintenance
{
    public class BillingBasis
    {
        public int Id { get; set; }
        [Required]
        public string Basis { get; set; }
    }
}