using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class LawFirmContact
    {
        
        
        [Key]
        [Column(Order = 1)]
        public int LawFirmId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual LawFirm LawFirm { get; set; }
        
    }
}