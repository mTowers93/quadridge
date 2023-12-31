﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Quadridge2.Models.Maintenance
{
    public class Province
    {
        public int Id { get; set; }

        public string Code {get; set;}

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}