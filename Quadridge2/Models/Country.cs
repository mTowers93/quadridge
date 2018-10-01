using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}