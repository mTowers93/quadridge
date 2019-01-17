using Quadridge2.Models;
using Quadridge2.Models.Deals;
using Quadridge2.Models.Maintenance;
using Quadridge2.ViewModels;
using Quadridge2.ViewModels.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
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
                _context.Structures.Add(structure);
            else
            {
                var structureInDb = _context.Structures.Single(s => s.Id == structure.Id);

                structureInDb.Name = structure.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Structures");
        }
    }
}