using Quadridge2.Models;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class InstitutesController : Controller
  {
    private ApplicationDbContext _context = new ApplicationDbContext();

    public InstitutesController()
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
      var institutes = _context.Institutes.ToList();
      return View(institutes);
    }

    public ActionResult New()
    {
      return View();
    }

    public ActionResult Save(Institute institute)
    {
      if (!ModelState.IsValid)
      {
        var viewModel = new InstituteViewModel
        {
          Institute = institute,
          InstitutionTypes = _context.InstitutionTypes.ToList()
        };

        return View("InstituteForm", viewModel);
      }
      if (institute.Id == 0)
        _context.Institutes.Add(institute);
      else
      {
        var instituteInDb = _context.Institutes.Single(l => l.Id == institute.Id);
        instituteInDb.Name = institute.Name;
        instituteInDb.TypeId = institute.TypeId;
        instituteInDb.Locations = institute.Locations;
      }
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "LawFirms");
      _context.SaveChanges();
      return Json(new { Url = redirectUrl });
    }
  }
}