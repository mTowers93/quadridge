using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.Models.Maintenance
{
  public class InstitutionType
  {
    public int Id {get; set;}

    [Required]
    public string Type { get; set; }
  }
}