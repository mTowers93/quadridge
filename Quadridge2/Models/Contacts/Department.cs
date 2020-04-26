﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Contacts
{
  public class Department
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
  }
}