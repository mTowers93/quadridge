using Quadridge2.ViewModels.LawFirms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quadridge2.Models;

namespace Quadridge2.Controllers
{
  public class LawFirmsController : Controller
  {
    private ApplicationDbContext _context = new ApplicationDbContext();

    public LawFirmsController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    // GET: LawFirms
    public ActionResult Index()
    {
      var lawType = _context.InstitutionTypes.SingleOrDefault(it => it.Type == "Law Firm");
      var lawFirms = _context.Institutes.Where(i => i.TypeId == lawType.Id).ToList();
      return View(lawFirms);
    }

    public ActionResult New()
    {
      var viewModel = new LawFirmFormViewModel()
      {
        Provinces = _context.Provinces.ToList(),
        Countries = _context.Countries.ToList()
      };
      return View("LawFirmForm", viewModel);
    }

    public ActionResult Save(Institute lawFirm)
    {
      if (!ModelState.IsValid)
      {
        return View("Index", lawFirm);
      }
      lawFirm.Type = _context.InstitutionTypes.SingleOrDefault(x => x.Type == "Law Firm");
      if (lawFirm.Id == 0)
        _context.Institutes.Add(lawFirm);
      else
      {
        var lawFirmInDb = _context.Institutes.Single(l => l.Id == lawFirm.Id);
        lawFirmInDb.Name = lawFirm.Name;
      }
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "LawFirms");
      _context.SaveChanges();
      return Json(new { Url = redirectUrl });
    }

    // GET: LawFirms/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var lawFirm = _context.Institutes.Find(id);
      if (lawFirm == null)
      {
        return HttpNotFound();
      }
      var viewModel = new LawFirmDetailsViewModel()
      {
        LawFirm = lawFirm,
        Contacts = _context.Contacts.ToList(),
        Structures = _context.Structures.ToList(),
        LfContacts = _context.Contacts.Where(x => x.InstituteId == id).ToList(),
        LfStructures = _context.Structures.Where(x => x.InstituteId == id).ToList()
      };
      return View(viewModel);
    }

    // POST: LawFirms/Delete/5
    public ActionResult Delete(int id)
    {
      LawFirm lawFirm = _context.LawFirms.Single(l => l.Id == id);
      if (lawFirm == null)
        return HttpNotFound();

      _context.LawFirms.Remove(lawFirm);
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "LawFirms");
      _context.SaveChanges();
      return Json(new { Url = redirectUrl });
    }

    public ActionResult AssignContacts(int id, List<int> contacts)
    {
      if (contacts.Count() > 0)
      {
        for (int i = 0; i < contacts.Count(); i++)
        {
          var contactId = contacts[i];
          var contactInDb = _context.Contacts.Single(x => x.Id == contactId);
          if (contactInDb.InstituteId != null)
            contactInDb.InstituteId = null;
          contactInDb.InstituteId = id;
        }
        _context.SaveChanges();
      }
      return RedirectToAction("Details", "FinancialInstitutions", new { id }); ;
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
