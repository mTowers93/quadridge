using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.ViewModels.FinancialInstitutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class FinancialInstitutionsController : Controller
  {
    private ApplicationDbContext _context;

    public FinancialInstitutionsController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }


    // GET: Banks
    public ActionResult Index()
    {
      var financialType = _context.InstitutionTypes.SingleOrDefault(it => it.Type == "Financial");
      var financialInstitutions = _context.Institutes.Where(i => i.TypeId == financialType.Id).ToList();
      return View(financialInstitutions);
    }

    public ActionResult New()
    {
      var institute = new Institute { Type = _context.InstitutionTypes.SingleOrDefault(x => x.Type == "Financial") };

      return View("FinancialInstitutionForm", institute);
    }

    [HttpPost]
    public ActionResult Save(Institute financialInstitution)
    {
      if (!ModelState.IsValid)
      {
        return View("FinancialInstitutionForm", financialInstitution);
      }
      financialInstitution.Type = _context.InstitutionTypes.FirstOrDefault(x => x.Type == "Financial");
      financialInstitution.TypeId = financialInstitution.Type.Id;
      if (financialInstitution.Id == 0)
        _context.Institutes.Add(financialInstitution);
      else
      {
        var financialInstitutionInDb = _context.Institutes.Single(c => c.Id == financialInstitution.Id);

        financialInstitutionInDb.Name = financialInstitution.Name;
        financialInstitutionInDb.TypeId = financialInstitution.TypeId;
      }
      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "FinancialInstitutions");
      _context.SaveChanges();
      return Json(new { Url = redirectUrl });

    }

    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      };

      var financialInstitutionInDb = _context.Institutes.SingleOrDefault(b => b.Id == id);

      if (financialInstitutionInDb == null)
      {
        return HttpNotFound();
      }
      _context.Institutes.Remove(financialInstitutionInDb);
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "FinancialInstitutions");
      _context.SaveChanges();
      return Json(new { Url = redirectUrl });
    }

    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      };

      var financialInstitution = _context.Institutes
                                 .Where(c => c.Id == id)
                                 .SingleOrDefault();
      if (financialInstitution == null)
        return HttpNotFound();

      var viewModel = new FinancialInstitutionDetailsViewModel()
      {
        FinancialInstitution = financialInstitution,
        Structures = _context.Structures.ToList(),
        FiStructures = _context.Structures.Where(x => x.InstituteId == id).ToList(),
        Contacts = _context.Contacts.ToList(),
        FiContacts = _context.Contacts.Where(x => x.InstituteId == id).ToList()
      };
      return View(viewModel);
    }

    public ActionResult AssignContacts(int id, List<int> contacts)
    {
      if (contacts.Count() > 0)
      {
        for (int i = 0; i < contacts.Count(); i++)
        {
          var contactId = contacts[i];
          var addFinContact = new FinancialInstitutionContact()
          {
            FinancialInstitutionId = id,
            ContactId = contactId
          };
          _context.FinancialInstitutionContacts.Add(addFinContact);
        }
        _context.SaveChanges();
      }
      return RedirectToAction("Details", "FinancialInstitutions", new { id }); ;
    }

    public ActionResult AssignStructures(int id, List<int> structures)
    {
      if (structures.Count() > 0)
      {
        for (int i = 0; i < structures.Count(); i++)
        {
          var structureId = structures[i];
          var structureInDb = _context.Structures.Single(s => s.Id == structureId);
          if (structureInDb.InstituteId != null)
            structureInDb.InstituteId = null;
          structureInDb.InstituteId = id;
        }
        _context.SaveChanges();
      }
      return RedirectToAction("Details", "FinancialInstitutions", new { id });
    }

    public ActionResult RemoveStructure(int? id, int? sid)
    {
      if (sid == null || id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var structureInDb = _context.Structures.Single(s => s.Id == sid);
      if (structureInDb == null)
        return HttpNotFound();

      structureInDb.InstituteId = null;
      _context.SaveChanges();

      return RedirectToAction("Details", new { id });
    }

    public ActionResult RemoveContact(int? id, int? cid)
    {
      if (cid == null || id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var fiContact = _context.FinancialInstitutionContacts.Single(f => f.FinancialInstitutionId == id && f.ContactId == cid);
      if (fiContact == null)
        return HttpNotFound();

      _context.FinancialInstitutionContacts.Remove(fiContact);
      _context.SaveChanges();

      return RedirectToAction("Details", new { id });
    }
  }
}