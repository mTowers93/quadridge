using Quadridge2.Models;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var viewModel = new TrustFormViewModel()
            {
                Services = _context.Services.ToList(),
                Structures = _context.Structures.ToList()
            };
            return View("TrustForm", viewModel);
        }

        public ActionResult Save(Trust trust)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TrustFormViewModel()
                {
                    Trust = trust,
                    Services = _context.Services.ToList(),
                    Structures = _context.Structures.ToList()
                };
                return View("TrustForm", viewModel);
            }

            if (trust.Id == 0)
                _context.Trusts.Add(trust);
            else
            {
                var trustInDb = _context.Trusts.Single(t => t.Id == trust.Id);
                trustInDb.Name = trust.Name;
                trustInDb.StructureId = trust.StructureId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Structures");
        }
    }
}