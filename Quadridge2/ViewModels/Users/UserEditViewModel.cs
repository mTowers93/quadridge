using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quadridge2.Models;
using System.Web.Mvc;

namespace Quadridge2.ViewModels.Users
{
  public class UserEditViewModel
  {
    public ApplicationUser user { get; set; }
    public IEnumerable<SelectListItem> rolesList { get; set; }
  }
}