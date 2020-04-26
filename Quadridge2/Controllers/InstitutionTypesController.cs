using Quadridge2.Models;
using Quadridge2.Models.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class InstitutionTypesController : Controller
  {
    private ApplicationDbContext _context = new ApplicationDbContext();

    public InstitutionTypesController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }
    // GET: Institutes

    public ActionResult Index()
    {
      var it = _context.InstitutionTypes.ToList();
      return View(it);
    }

    public ActionResult New()
    {
      return View();
    }

    public ActionResult Save(InstitutionType it)
    {
      if (!ModelState.IsValid)
      {
        Console.Write(it.Type);
        return View(it);
      }
      if (it.Id == 0)
        _context.InstitutionTypes.Add(it);
      else
      {
        var institutionTypeInDb = _context.InstitutionTypes.Single(i => i.Id == it.Id);
        institutionTypeInDb.Type = it.Type;
      }
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Institutionypes");
      _context.SaveChanges();
      return Json(new { Url = redirectUrl });
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
      var InstitutionInDb = _context.InstitutionTypes.SingleOrDefault(i => i.Id == id);

      if (InstitutionInDb == null)
        HttpNotFound();

      _context.InstitutionTypes.Remove(InstitutionInDb);
      _context.SaveChanges();

      return RedirectToAction("Index", "InstitutionTypes");
    }
  }
}