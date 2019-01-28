using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class CompanyContact
    {
        [Key]
        [Column(Order = 1)]
        public int CompanyId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ContactId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Contact Contact { get; set; }
    }
}