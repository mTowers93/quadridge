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
            var otherInstitutions = _context.OtherInstitutions.ToList();
            return View(otherInstitutions);
        }

        [HttpPost]
        public ActionResult Save(OtherInstitution otherInstitution)
        {
            if (otherInstitution.Id == 0)
                _context.OtherInstitutions.Add(otherInstitution);
            else
            {
                var otherInstitutionInDb = _context.OtherInstitutions.Single(c => c.Id == otherInstitution.Id);

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

            var otherInstitutionInDb = _context.OtherInstitutions.SingleOrDefault(b => b.Id == id);

            if (otherInstitutionInDb == null)
            {
                return HttpNotFound();
            }
            _context.OtherInstitutions.Remove(otherInstitutionInDb);
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "OtherInstitutions");
            _context.SaveChanges();
            return Json(new { Url = redirectUrl });
        }
        
        public ActionResult Details(int id)
        {
            var otherInstitution = _context.OtherInstitutions.Single(o => o.Id == id);
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

        public ActionResult AssignContacts(int id, List<int> contacts)
        {
            if (contacts.Count() > 0)
            {
                for (int i = 0; i < contacts.Count(); i++)
                {
                    var contactId = contacts[i];
                    var addStandaloneContact = new StandaloneContact()
                    {
                        StandAloneId = id,
                        ContactId = contactId
                    };
                    _context.StandaloneContacts.Add(addStandaloneContact);
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
                    if (structureInDb.FinancialInstitutionId != null)
                        structureInDb.FinancialInstitutionId = null;
                    structureInDb.OtherInstitutionId = id;
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

            structureInDb.OtherInstitutionId = null;
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