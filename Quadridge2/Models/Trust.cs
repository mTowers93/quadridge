using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.Models
{
    public class Trust
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Donor { get; set; }

        public Structure Structure { get; set; }

        [Display(Name = "Associated Structure")]
        public int? StructureId { get; set; }

        public DateTime AppointmentDate { get; set;}

        [Display(Name = "Trustee Representitive")]
        public string TrusteeRepresentitive { get; set; }

        public ICollection<Company> Companies { get; set; }

        public ICollection<TrustService> TrustServices { get; set; }
    }
}