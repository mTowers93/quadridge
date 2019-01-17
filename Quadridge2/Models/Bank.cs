using Quadridge2.Models.Maintenance;
using Quadridge2.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Bank
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<BankOffice> BankOffices { get; set; }
        public ICollection<BankContact> BankContacts { get; set; }
    }
}