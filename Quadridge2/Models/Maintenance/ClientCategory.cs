using Quadridge2.Models.Deals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Maintenance
{
    public class ClientCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<Structure> Structures { get; set; }
    }
}