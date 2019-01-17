using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models.Maintenance
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }
    }
}