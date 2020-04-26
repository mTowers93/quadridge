using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class StandaloneContact
    {
        
        [Key]
        [Column(Order = 1)]
        [Display(Name="Other")]
        public int StandAloneId { get; set; }

        [Key]
        [Column(Order =2 )]
        [Display(Name = "Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
        public Standalone Standalone { get; set; }
        
    }
}