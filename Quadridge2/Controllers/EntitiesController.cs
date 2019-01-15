using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quadridge2.ViewModels.Entities;

namespace Quadridge2.Controllers
{
    public class EntitiesController : Controller
    {
        private ApplicationDbContext _context;

        public EntitiesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Entities
        public ActionResult Index()
        {
            var Entities = _context.Entities.ToList();
            return View(Entities);
        }

        public ActionResult New()
        {
            var viewModel = new EntityFormViewModel
            {
                Services = _context.Services.ToList(),
                Trusts = _context.Trusts.ToList(),
                BillingBases = _context.BillingBases.ToList(),
                FeeTypes = _context.FeeTypes.ToList(),
                Structures = _context.Structures.ToList()
            };
            return View("EntityForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Entity entity)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EntityFormViewModel
                {
                    Entity = entity,
                    Services = _context.Services.ToList(),
                    Trusts = _context.Trusts.ToList(),
                    FeeTypes = _context.FeeTypes.ToList(),
                    BillingBases = _context.BillingBases.ToList(),
                    Structures = _context.Structures.ToList()
                };

                return View("EntityForm", viewModel);
            }
            if (entity.Id == 0)
                _context.Entities.Add(entity);
            else
            {
                var entityInDb = _context.Entities.Single(c => c.Id == entity.Id);

                entityInDb.Name = entity.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Entities");

        }
    }
}