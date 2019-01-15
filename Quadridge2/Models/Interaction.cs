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

        public InteractionType InteractionType { get; set; }

        [Required]
        [Display(Name="Interaction Type")]
        public int InteractionTypeId { get; set; }

        [Required]
        [Display(Name ="Date")]
        public DateTime InteractionDate { get; set; }

        [Required]
        [Display(Name ="Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public string Comment { get; set; }

    }
}