using Quadridge2.Models.Maintenance;
using Quadridge2.Models.Contacts;
using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.Models
{
    public class Entity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Display(Name="Directorship Start Date")]
        public DateTime DirectorshipStartDate { get; set; }

        [Display(Name="First Billing Date")]
        public DateTime FirstBillingDate { get; set; }

        public BillingBasis BillingBasis { get; set; }
        [Display(Name="Billing Basis")]
        public int? BillingBasisId { get; set; }
        
        public FeeType FeeType { get; set; }
        [Display(Name="Fee Type")]
        public int? FeeTypeId { get; set; }

        // Relationships
         
        public Trust Trust { get; set; }

        [Display(Name ="Associated Trust")]
        public int? TrustId { get; set; }

        public Structure Structure { get; set; }

        [Display(Name="Structure")]
        public int? StructureId { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}