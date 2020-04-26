using Quadridge2.Models;
using Quadridge2.ViewModels.Trusts;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class TrustsController : Controller
  {
    private ApplicationDbContext _context;

    public TrustsController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }
    // GET: Trusts
    public ActionResult Index()
    {
      var trusts = _context.Trusts.ToList();
      return View(trusts);
    }

    public ActionResult New()
    {
      var services = _context.Services.ToList();
      var servicesL = new List<ServiceCheckboxItem>();
      foreach (var service in services)
      {
        servicesL.Add(new ServiceCheckboxItem
        {
          Name = service.Name,
          Id = service.Id,
          IsChecked = false
        });
      }

      var viewModel = new TrustFormViewModel()
      {
        Services = servicesL,
        Structures = _context.Structures.ToList(),
        Trust = new Trust() { }
    };
            return View("TrustForm", viewModel);
  }

  public ActionResult Edit(int id)
  {
    var trust = _context.Trusts.Single(c => c.Id == id);
    if (trust == null)
      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    var services = _context.Services.ToList();
    var listOfChosenServicesTemp = _context.TrustServices.Where(s => s.TrustId == id).ToList();
    var listOfServices = new List<ServiceCheckboxItem>();

    foreach (var service in services)
    {
      listOfServices.Add(new ServiceCheckboxItem
      {
        Name = service.Name,
        Id = service.Id,
        IsChecked = listOfChosenServicesTemp.Where(s => s.ServiceId == service.Id).Any()
      });
    }

    var viewModel = new TrustFormViewModel()
    {
      Trust = trust,
      Services = listOfServices,
      Structures = _context.Structures.ToList()
    };

    return View("TrustForm", viewModel);
  }

  public ActionResult Save(TrustFormViewModel viewModel)
  {
    if (!ModelState.IsValid)
    {
      return View("TrustForm", viewModel);
    }

    if (viewModel.Trust.Id == 0)
    {
      _context.Trusts.Add(viewModel.Trust);
      _context.SaveChanges();
    }


    else
    {
      var trustInDb = _context.Trusts.Single(t => t.Id == viewModel.Trust.Id);
      trustInDb.Name = viewModel.Trust.Name;
      trustInDb.StructureId = viewModel.Trust.StructureId;
      trustInDb.RegistrationDate = viewModel.Trust.RegistrationDate;
      trustInDb.Donor = viewModel.Trust.Donor;
      trustInDb.TrusteeRepresentitive = viewModel.Trust.TrusteeRepresentitive;
    }

    if (viewModel.Services.Count() > 0)
    {
      var companyServices = _context.TrustServices.Where(c => c.TrustId == viewModel.Trust.Id).ToList();

      foreach (var service in viewModel.Services)
      {
        var serviceId = service.Id;
        if (service.IsChecked)
        {
          var addService = new TrustService()
          {
            Service = _context.Services.Single(s => s.Id == serviceId),
            ServiceId = serviceId,
            Trust = viewModel.Trust,
            TrustId = viewModel.Trust.Id
          };
          if (!companyServices.Exists(c => c.ServiceId == serviceId & c.TrustId == viewModel.Trust.Id))
            _context.TrustServices.Add(addService);
        }
        else
        {
          if (companyServices.Exists(c => c.ServiceId == serviceId & c.TrustId == viewModel.Trust.Id))
          {
            var removeService = companyServices.Where(s => s.ServiceId == service.Id).First();
            _context.TrustServices.Remove(removeService);
          }
        }
      }
      _context.SaveChanges();
    }
    return RedirectToAction("Index", "Trusts");
  }

  public ActionResult Delete(int? id)
  {
    if (id == null)
    {
      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    };

    var trustInDb = _context.Trusts.SingleOrDefault(b => b.Id == id);

    if (trustInDb == null)
    {
      return HttpNotFound();
    }
    _context.Trusts.Remove(trustInDb);
    _context.SaveChanges();

    var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Trusts");
    _context.SaveChanges();
    return Json(new { Url = redirectUrl });
  }

  public ActionResult Details(int? id)
  {
    if (id == null)
    {
      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    };

    var trust = _context.Trusts
                .Where(t => t.Id == id)
                .Single();

    if (trust == null)
      HttpNotFound();

    var viewModel = new TrustDetailsViewModel()
    {
      Trust = trust,
      Companies = _context.Companies.ToList()
    };

    return View(viewModel);
  }
}
}