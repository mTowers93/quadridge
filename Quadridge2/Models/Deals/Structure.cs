using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quadridge2.Models.Deals
{
    public class Structure
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name="Referral")]
        public Contact Contact { get; set; }
        [Display(Name = "Referral")]
        public int? ContactId { get; set; }

        [Display(Name="Referral Institution")]
        public int? ReferralInstitutionId { get; set; }
        public virtual Institute ReferralInstitution { get; set; }

        [Display(Name = "Law Firm Contact")]
        public int? LawFirmContactId { get; set; }

        // Relationships

        public virtual StructureCategory StructureCategory { get; set; }
        [Display(Name=("Structure Category"))]
        public int StructureCategoryId { get; set; }

        public virtual Institute Institute { get; set; }
        [Display(Name="Institute")]
        public int? InstituteId { get; set; }

        public virtual Institute LawFirm { get; set; }
        [Display(Name="Law Firm")]
        public int? LawFirmId { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<Trust> Trusts { get; set; }

        public virtual ICollection<StructureContact> StructureContacts { get; set; }

        public virtual Status Status { get; set; }
        [Display(Name="Status")]
        public int StatusId { get; set; }
    }
}