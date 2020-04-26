using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Quadridge2.Models;
using Quadridge2.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Quadridge2.Controllers
{
  public class UsersAdminController : Controller
  {
    public UsersAdminController()
    {
    }

    private ApplicationSignInManager _signInManager;

    public ApplicationSignInManager SignInManager
    {
      get
      {
        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
      }
      private set
      {
        _signInManager = value;
      }
    }

    private ApplicationRoleManager _roleManager;
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

    public UsersAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
    {
      UserManager = userManager;
      RoleManager = roleManager;
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

    private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError("", error);
      }
    }

    // GET: UsersAdmin
    public ActionResult Index()
    {
      return View(UserManager.Users.ToList());
    }

    public async Task<ActionResult> Edit(string id)
    {
      var contact = UserManager.Users.FirstOrDefault(u => u.Id == id);
      if (contact == null)
        return new HttpStatusCodeResult(HttpStatusCode.NotFound);

      var userRoles = await UserManager.GetRolesAsync(contact.Id).ConfigureAwait(false);
      var viewModel = new UserEditViewModel()
      {
        user = contact,
        rolesList = RoleManager.Roles.ToList().Select(x => new SelectListItem()
        {
          Selected = userRoles.Contains(x.Name),
          Text = x.Name,
          Value = x.Name
        })
      };

      return View("UserForm", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(UserEditViewModel model, params string[] selectedRole)
    {
      if (ModelState.IsValid)
      {
        var user = await UserManager.FindByIdAsync(model.user.Id).ConfigureAwait(false);
        user.FirstName = model.user.FirstName;
        user.LastName = model.user.LastName;
        user.Email = model.user.Email;
        user.PhoneNumber = model.user.PhoneNumber;

        var userRoles = await UserManager.GetRolesAsync(user.Id).ConfigureAwait(false);
        selectedRole = selectedRole ?? Array.Empty<string>();

        var result = await UserManager.AddToRolesAsync(user.Id, selectedRole.Except(userRoles).ToArray()).ConfigureAwait(false);

        if (!result.Succeeded)
        {
          ModelState.AddModelError("", result.Errors.First());
          return View();
        }
        result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRole).ToArray()).ConfigureAwait(false);

        if (!result.Succeeded)
        {
          ModelState.AddModelError("", result.Errors.First());
          return View();
        }
      return RedirectToAction("Index");
    }
    ModelState.AddModelError("", "Something failed."); 
    return View();

  }

  [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Save(RegisterViewModel model)
    {
      if (ModelState.IsValid)
      {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await UserManager.CreateAsync(user, model.Password).ConfigureAwait(false);
        if (result.Succeeded)
        {
          //temp code
          // var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
          // var roleManager = new RoleManager<IdentityRole>(roleStore);
          // await roleManager.CreateAsync(new IdentityRole("Employee"));
          // await UserManager.AddToRoleAsync(user.Id, "Employee");

          await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false).ConfigureAwait(false);

          // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
          // Send an email with this link
          // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
          // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
          // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

          return RedirectToAction("Index", "Home");
        }
        AddErrors(result);
      }
      // If we got this far, something failed, redisplay form
      return View("userForm", model);
    }
  }
}