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

        public Structure Structure { get; set; }

        [Display(Name="Associated Structure")]
        public int? StructureId { get; set; }

        public IEnumerable<Entity> Entities { get; set; }
    }
}