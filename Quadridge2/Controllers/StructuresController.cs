using Quadridge2.Models;
using Quadridge2.Models.Deals;
using Quadridge2.Models.Maintenance;
using Quadridge2.ViewModels;
using Quadridge2.ViewModels.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class StructuresController : Controller
    {
        private ApplicationDbContext _context;

        public StructuresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Structures
        public ActionResult Index()
        {
            var structures = _context.Structures.ToList();
            return View(structures);
        }

        public ActionResult New()
        {
            var viewModel = new StructureFormViewModel
            {
                StructureCategories = _context.StructureCategories.ToList(),
                FinancialInstitutions = _context.FinancialInstitutions.ToList(),
                OtherInstitutions = _context.OtherInstitutions.ToList(),
                Statuses = _context.Statuses.ToList(),
                isFinancialInst = false,
                isOtherInst = false,
                Contacts = _context.Contacts.ToList()
            };
            return View("StructureForm", viewModel);
        }

        public ActionResult Save(Structure structure)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StructureFormViewModel
                {
                    Structure = structure
                };

                return View("StructureForm", viewModel);
            }
            if (structure.Id == 0)
            {
                if (structure.ContactId != 0)
                    structure.Contact = _context.Contacts.Single(c => c.Id == structure.ContactId);
                _context.Structures.Add(structure);
            }
            else
            {
                var structureInDb = _context.Structures.Single(s => s.Id == structure.Id);

                structureInDb.Name = structure.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Structures");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var structureInDb = _context.Structures.Single(s => s.Id == id);

            if (structureInDb == null)
                HttpNotFound();

            _context.Structures.Remove(structureInDb);
            _context.SaveChanges();

            return RedirectToAction("index", "Structures");

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var structure = _context.Structures
                            .Where(s => s.Id == id)
                            .Single();

            if (structure == null)
                HttpNotFound();

            structure.Contact = _context.Contacts.Single(c => c.Id == structure.ContactId);

            var viewModel = new StructuresDetailsViewModel()
            {
                Structure = structure,
                Companies = _context.Companies.ToList(),
                Trusts = _context.Trusts.ToList()
            };

            return View(viewModel);
        }

        public ActionResult AssignCompanies(int id, List<int> companies)
        {
            if (companies.Count() > 0)
            {
                for (int i = 0; i < companies.Count(); i++)
                {
                    var companyId = companies[i];
                    var companyInDb = _context.Companies.SingleOrDefault(c => c.Id == companyId);
                    companyInDb.StructureId = id;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Details", new { id });
        }

        public ActionResult AssignTrusts(int id, List<int> trusts)
        {
            if (trusts.Count() > 0)
            {
                for (int i = 0; i < trusts.Count(); i++)
                {
                    var trustId = trusts[i];
                    var trustInDb = _context.Trusts.SingleOrDefault(t => t.Id == trustId);
                    trustInDb.StructureId = id;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Details", new { id });
        }

        public ActionResult RemoveTrust(int? id, int? tid)
        {
            if (tid == null || id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var trustInDb = _context.Trusts.Single(s => s.Id == tid);
            if (trustInDb == null)
                return HttpNotFound();

            trustInDb.StructureId = null;
            _context.SaveChanges();

            return RedirectToAction("Details", new { id });
        }

        public ActionResult RemoveCompany(int? id, int? tid)
        {
            if (tid == null || id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var trustInDb = _context.Trusts.Single(s => s.Id == tid);
            if (trustInDb == null)
                return HttpNotFound();

            trustInDb.StructureId = null;
            _context.SaveChanges();

            return RedirectToAction("Details", new { id });
        }
    }
}