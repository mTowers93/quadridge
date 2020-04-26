using Quadridge2.Models.Contacts;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class LawFirm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<LawFirmContact> LawFirmContacts { get; set; }

    }
}