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
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name="Registration Number")]
        public string RegistrationNumber { get; set; }

        [Display(Name="Directorship Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}")] //Format as ShortDateTime
        public DateTime DirectorshipStartDate { get; set; }

        [Display(Name="First Billing Date")]
        [DisplayFormat(DataFormatString = "{0:d}")] //Format as ShortDateTime
        public DateTime FirstBillingDate { get; set; }

        public virtual BillingBasis BillingBasis { get; set; }
        [Display(Name="Billing Basis")]
        public int? BillingBasisId { get; set; }
        
        public virtual FeeType FeeType { get; set; }
        [Display(Name="Fee Type")]
        public int? FeeTypeId { get; set; }

        // Relationships
         
        public virtual Trust Trust { get; set; }

        [Display(Name ="Associated Trust")]
        public int? TrustId { get; set; }

        public virtual Structure Structure { get; set; }

        [Display(Name="Structure")]
        public int? StructureId { get; set; }

        public virtual ICollection<CompanyContact> CompanyContacts { get; set; }

        public virtual ICollection<CompanyService> CompanyServices { get; set; }
    }
}