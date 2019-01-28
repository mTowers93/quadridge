using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
    public class StructureContact
    {
        [Key]
        [Column(Order =1)]
        public int StructureId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ContactId { get; set; }

        public virtual Structure Structure { get; set; }
        public virtual Contact Contact { get; set; }
    }
}