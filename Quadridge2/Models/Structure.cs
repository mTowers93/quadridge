using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
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
        public int ContactId { get; set; }

        // Relationships

        public StructureCategory StructureCategory { get; set; }
        [Display(Name=("Structure Category"))]
        public int StructureCategoryId { get; set; }

        public IEnumerable<Entity> Entities { get; set; }

        public IEnumerable<Trust> Trusts { get; set; }
    }
}