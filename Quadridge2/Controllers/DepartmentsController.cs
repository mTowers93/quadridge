using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class DepartmentsController : Controller
  {

    private ApplicationDbContext _context;

    public DepartmentsController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    // GET: Statuses
    public ActionResult Index()
    {
      var statuses = _context.Departments.ToList();
      return View(statuses);
    }

    public ActionResult Save(Department department)
    {
      if (department.Id == 0)
        _context.Departments.Add(department);
      else
      {
        var statusInDb = _context.Statuses.Single(s => s.Id == department.Id);
        statusInDb.Type = department.Name;
      }
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Departments"); ;
      return Json(new { Url = redirectUrl });
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var departmentInDb = _context.Departments.Single(s => s.Id == id);

      if (departmentInDb == null)
        return HttpNotFound();

      _context.Departments.Remove(departmentInDb);
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Departments");
      return Json(new { Url = redirectUrl });
    }
  }
}