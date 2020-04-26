using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;
using Quadridge2.Models.Maintenance;

namespace Quadridge2.ViewModels
{
  public class InstituteViewModel
  {
    public Institute Institute { get; set; }
    public virtual ICollection<InstitutionType> InstitutionTypes { get; set; }
  }
}