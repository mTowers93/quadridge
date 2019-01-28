using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class FinancialInstitutionContact
    {
        [Key]
        [Column(Order = 1)]
        public int FinancialInstitutionId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ContactId { get; set; }

        public virtual FinancialInstitution FinancialInstitution { get; set; }
        public virtual Contact Contact { get; set; }
    }
}