using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        // Relationships

        public StructureCategory StructureCategory { get; set; }
        [Display(Name=("Structure Category"))]
        public int StructureCategoryId { get; set; }

        public virtual FinancialInstitution FinancialInstitution { get; set; }
        [Display(Name="Financial Institution")]
        public int? FinancialInstitutionId { get; set; }

        public virtual OtherInstitution OtherInstitution { get; set; }
        [Display(Name="Other Institution")]
        public int? OtherInstitutionId { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<Trust> Trusts { get; set; }

        public virtual ICollection<StructureContact> StructureContacts { get; set; }

        public virtual Status Status { get; set; }
        [Display(Name="Status")]
        public int StatusId { get; set; }
    }
}