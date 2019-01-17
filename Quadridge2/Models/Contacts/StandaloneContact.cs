using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class StandaloneContact
    {
        public int? Id { get; set; }
        
        public Standalone Standalone { get; set; }
        [Display(Name="Other")]
        public int StandAloneId { get; set; }

        public Contact Contact { get; set; }
        [Display(Name ="Contact")]
        public int ContactId { get; set; }
    }
}