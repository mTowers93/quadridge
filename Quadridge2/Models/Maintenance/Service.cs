using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Maintenance
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<CompanyService> CompanyServices { get; set; }
        public virtual ICollection<TrustService> TrustServices { get; set; }
    }
}