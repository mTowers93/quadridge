using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Interaction
    {
        public int Id { get; set; }

        public virtual InteractionType InteractionType { get; set; }

        [Required]
        [Display(Name="Interaction Type")]
        public int InteractionTypeId { get; set; }

        [Required]
        [Display(Name ="Date")]
        public DateTime InteractionDate { get; set; }

        [Required]
        [Display(Name ="Contact")]
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }

        public string Comment { get; set; }

    }
}