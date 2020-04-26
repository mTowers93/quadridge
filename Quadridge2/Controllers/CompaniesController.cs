using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quadridge2.ViewModels.Companies;
using Quadridge2.ViewModels;
using System.Net;

namespace Quadridge2.Controllers
{
  public class CompaniesController : Controller
  {
    private ApplicationDbContext _context;

    public CompaniesController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    // GET: Companies
    public ActionResult Index()
    {
      var companies = _context.Companies.ToList();
      return View(companies);
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
      var viewModel = new CompanyFormViewModel
      {
        Services = servicesL,
        Trusts = _context.Trusts.ToList(),
        BillingBases = _context.BillingBases.ToList(),
        FeeTypes = _context.FeeTypes.ToList(),
        Structures = _context.Structures.ToList(),
        Company = new Company() { }
      };
      return View("CompanyForm", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Save(CompanyFormViewModel viewModel)
    {
      if (!ModelState.IsValid)
      {
        //            var errors = ModelState
        //.Where(x => x.Value.Errors.Count > 0)
        //.Select(x => new { x.Key, x.Value.Errors })
        //.ToArray();

        return View("CompanyForm", viewModel);
      }
      if (viewModel.Company.Id == 0)
      {
        _context.Companies.Add(viewModel.Company);
        _context.SaveChanges();

      }
      else
      {
        var companyInDb = _context.Companies.Single(c => c.Id == viewModel.Company.Id);

        companyInDb.Name = viewModel.Company.Name;
        companyInDb.RegistrationNumber = viewModel.Company.RegistrationNumber;
        companyInDb.RegisteredName = viewModel.Company.RegisteredName;
        companyInDb.StructureId = viewModel.Company.StructureId;
        companyInDb.TrustId = viewModel.Company.TrustId;
        companyInDb.FirstBillingDate = viewModel.Company.FirstBillingDate;
        companyInDb.DirectorshipStartDate = viewModel.Company.DirectorshipStartDate;
        companyInDb.BillingBasisId = viewModel.Company.BillingBasisId;
        companyInDb.FeeTypeId = viewModel.Company.FeeTypeId;
        _context.SaveChanges();
      }

      if (viewModel.Services.Count() > 0)
      {
        var companyServices = _context.CompanyServices.Where(c => c.CompanyId == viewModel.Company.Id).ToList();

        foreach (var service in viewModel.Services)
        {
          var serviceId = service.Id;
          if (service.IsChecked)
          {
            var addService = new CompanyService()
            {
              Service = _context.Services.Single(s => s.Id == serviceId),
              ServiceId = serviceId,
              Company = viewModel.Company,
              CompanyId = viewModel.Company.Id
            };
            if (!companyServices.Exists(c => c.ServiceId == serviceId & c.CompanyId == viewModel.Company.Id))
              _context.CompanyServices.Add(addService);
          }
          else
          {
            if (companyServices.Exists(c => c.ServiceId == serviceId & c.CompanyId == viewModel.Company.Id))
            {
              var removeService = companyServices.Where(s => s.ServiceId == service.Id).First();
              _context.CompanyServices.Remove(removeService);
            }
          }
        }
        _context.SaveChanges();
      }
      return RedirectToAction("Index", "Companies");

    }

    public ActionResult Details(int id)
    {
      var company = _context.Companies.Single(c => c.Id == id);
      if (company == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var viewModel = new CompanyDetailsViewModel()
      {
        Company = company
      };
      ViewBag.Title = "Details for " + company.Name;
      return View(viewModel);
    }

    public ActionResult Edit(int id)
    {
      var company = _context.Companies.Single(c => c.Id == id);
      if (company == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var services = _context.Services.ToList();
      var listOfChosenServicesTemp = _context.CompanyServices.Where(s => s.CompanyId == id).ToList();
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

      var viewModel = new CompanyFormViewModel()
      {
        Company = company,
        Services = listOfServices,
        Trusts = _context.Trusts.ToList(),
        FeeTypes = _context.FeeTypes.ToList(),
        BillingBases = _context.BillingBases.ToList(),
        Structures = _context.Structures.ToList()
      };

      return View("CompanyForm", viewModel);
    }

    public ActionResult AssignContacts(int id, List<int> contacts)
    {
      if (contacts.Count() > 0)
      {
        for (int i = 0; i < contacts.Count(); i++)
        {
          var contactId = contacts[i];
          var addContact = new CompanyContact()
          {
            ContactId = contactId,
            CompanyId = id
          };
          _context.CompanyContacts.Add(addContact);
        }
        _context.SaveChanges();
      }
      return RedirectToAction("Details", new { id });
    }

    public ActionResult RemoveContact(int? id, int? cid)
    {
      if (cid == null || id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var companyContact = _context.CompanyContacts.Single(c => c.CompanyId == id && c.ContactId == cid);
      if (companyContact == null)
        return HttpNotFound();

      _context.CompanyContacts.Remove(companyContact);
      _context.SaveChanges();
      return RedirectToAction("Details", new { id });
    }

    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      };

      var companyInDb = _context.Companies.SingleOrDefault(b => b.Id == id);

      if (companyInDb == null)
      {
        return HttpNotFound();
      }
      _context.Companies.Remove(companyInDb);
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Companies");
      return Json(new { Url = redirectUrl });
    }
  }
}