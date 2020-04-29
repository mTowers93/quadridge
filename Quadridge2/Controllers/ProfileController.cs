using Microsoft.AspNet.Identity.Owin;
using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class ProfileController : Controller
  {
    private ApplicationDbContext _context;

    public ProfileController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    private ApplicationUserManager _userManager;
    public ApplicationUserManager UserManager

    {
      get
      {
        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
      }

      set
      {
        _userManager = value;
      }
    }

    // GET: Profile
    public ActionResult Index()
    {
      var user = HttpContext.User.Identity;
      return View(user);
    }
  }
}