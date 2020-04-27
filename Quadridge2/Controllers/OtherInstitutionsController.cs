using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
  public class OtherInstitutionsController : Controller
  {
    private ApplicationDbContext _context;

    public OtherInstitutionsController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }
    // GET: OtherInstitutions
    public ActionResult Index()
    {
      var type = _context.InstitutionTypes.Single(x => x.Type == "Other");
      var otherInstitutions = _context.Institutes.Where(x => x.TypeId == type.Id).ToList();
      return View(otherInstitutions);
    }

    [HttpPost]
    public ActionResult Save(Institute otherInstitution)
    {
      otherInstitution.Type = _context.InstitutionTypes.Single(x => x.Type == "Other");
      if (otherInstitution.Id == 0)
        _context.Institutes.Add(otherInstitution);
      else
      {
        var otherInstitutionInDb = _context.Institutes.Single(c => c.Id == otherInstitution.Id);

        otherInstitutionInDb.Name = otherInstitution.Name;
      }
      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "OtherInstitutions");
      _context.SaveChanges();
      return Json(new { Url = redirectUrl });

    }

    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      };

      var otherInstitutionInDb = _context.Institutes.SingleOrDefault(b => b.Id == id);

      if (otherInstitutionInDb == null)
      {
        return HttpNotFound();
      }
      _context.Institutes.Remove(otherInstitutionInDb);
      _context.SaveChanges();

      var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "OtherInstitutions");
      _context.SaveChanges();
      return Json(new { Url = redirectUrl });
    }

    public ActionResult Details(int id)
    {
      var otherInstitution = _context.Institutes.Single(o => o.Id == id);
      if (otherInstitution == null)
        HttpNotFound();
      var viewModel = new OtherInstitutionDetailViewModel()
      {
        OtherInstitution = otherInstitution,
        Contacts = _context.Contacts.ToList(),
        Structures = _context.Structures.ToList()
      };
      return View(viewModel);
    }

    [HttpPost]
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
      return RedirectToAction("Details", "OtherInstitutions", new { id }); ;
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
      return RedirectToAction("Details", "OtherInstitutions", new { id });
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
      var sacontact = _context.StandaloneContacts.Single(f => f.StandAloneId == id && f.ContactId == cid);
      if (sacontact == null)
        return HttpNotFound();

      _context.StandaloneContacts.Remove(sacontact);
      _context.SaveChanges();

      return RedirectToAction("Details", new { id });
    }
  }
}