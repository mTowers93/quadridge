using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class OtherInstitutionContact
    {
        [Key]
        [Column(Order= 1)]
        public int OtherInstitutionId { get; set; }
        [Key]
        [Column(Order=2)]
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual OtherInstitution OtherInstitution { get; set; }
        
    }
}