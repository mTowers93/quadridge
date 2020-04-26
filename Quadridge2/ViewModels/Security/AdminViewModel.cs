using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quadridge2.ViewModels.Security
{
  public class RoleViewModel
  {
    public string Id { get; set; }
    [Required]
    [Display(Name= "Role Name")]
    public string Name { get; set; }
  }
}