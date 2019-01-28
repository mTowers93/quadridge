using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Quadridge2.Models
{
    public class CompanyService
    {
        [Key]
        [Column(Order =1)]
        public int CompanyId { get; set; }
        [Key]
        [Column(Order =2)]
        public int ServiceId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Service Service { get; set; }

        public bool IsChecked { get; set; }
    }
}