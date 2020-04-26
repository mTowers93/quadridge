using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class RolesAdminController : Controller
  {
    public RolesAdminController()
    {
    }

    private ApplicationRoleManager _roleManager;

    public RolesAdminController(ApplicationRoleManager roleManager)
    {
      RoleManager = roleManager;
    }

    public ApplicationRoleManager RoleManager
    {
      get
      {
        return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
      }
      private set
      {
        _roleManager = value;
      }
    }

    // GET: RolesAdmin
    public ActionResult Index()
    {
      List<IdentityRole> roles = RoleManager.Roles.ToList();
      return View(roles);
    }

    public async Task<ActionResult> SaveR(string name)
    {
      IdentityRole role = new IdentityRole(name);
      var result = await RoleManager.CreateAsync(role).ConfigureAwait(false);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> Save(IdentityRole role)
    {
      if (role.Id != null)
      {
        var result = await RoleManager.CreateAsync(role).ConfigureAwait(false);
        return RedirectToAction("Index");
      }  
      else
      {
        var result = await RoleManager.UpdateAsync(role).ConfigureAwait(false);
      }

      return RedirectToAction("Index");
    }

  }
}