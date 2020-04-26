using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Quadridge2.Controllers
{
  public class AdminController : Controller
  {
    private ApplicationUserManager _userManager;

    public AdminController(ApplicationUserManager appUser) 
    {
      _userManager = appUser;
    }

    // GET: Admin
    public ActionResult Index()
    {
      return View(_userManager.Users);
    }
  }
}