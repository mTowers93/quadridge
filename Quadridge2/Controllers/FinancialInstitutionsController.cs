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
            var financialInstitutions = _context.FinancialInstitutions.ToList();
            return View(financialInstitutions);
        }

        public ActionResult New()
        {
            var viewModel = new FinancialInstitutionsFormViewModel
            {
                Provinces = _context.Provinces.ToList(),
                Countries = _context.Countries.ToList()
            };

            return View("FinancialInstitutionForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(FinancialInstitution financialInstitution)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FinancialInstitutionsFormViewModel
                {
                    FinancialInstitution = financialInstitution,
                    Provinces = _context.Provinces.ToList(),
                    Countries = _context.Countries.ToList()
                };

                return View("FinancialInstitutionForm", viewModel);
            }
            if (financialInstitution.Id == 0)
                _context.FinancialInstitutions.Add(financialInstitution);
            else
            {
                var financialInstitutionInDb = _context.FinancialInstitutions.Single(c => c.Id == financialInstitution.Id);

                financialInstitutionInDb.Name = financialInstitution.Name;
            }
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "FinancialInstitutions");
            _context.SaveChanges();
            return Json(new { Url = redirectUrl});

        }

        public ActionResult Delete(int? id)
        {           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };

            var financialInstitutionInDb = _context.FinancialInstitutions.SingleOrDefault(b => b.Id == id);

            if (financialInstitutionInDb == null)
            {
                return HttpNotFound();
            }
            _context.FinancialInstitutions.Remove(financialInstitutionInDb);
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

            var financialInstitution = _context.FinancialInstitutions
                                       .Include(c => c.FinancialInstitutionContacts)
                                       .Where(c => c.Id == id)
                                       .SingleOrDefault();
            if (financialInstitution == null)
                return HttpNotFound();

            var viewModel = new FinancialInstitutionDetailsViewModel()
            {
                FinancialInstitution = financialInstitution,
                Structures = _context.Structures.ToList(),
                Contacts = _context.Contacts.ToList()
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
                    if (structureInDb.OtherInstitutionId != null)
                        structureInDb.OtherInstitutionId = null;
                    structureInDb.FinancialInstitutionId = id;
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

            structureInDb.FinancialInstitutionId = null;
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