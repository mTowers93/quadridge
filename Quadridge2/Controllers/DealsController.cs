using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quadridge2.Models;
using Quadridge2.ViewModels;

namespace Quadridge2.Controllers
{
    public class DealsController : Controller
    {
        // GET: Deals
        private ApplicationDbContext _context;

        public DealsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new DealFormViewModel
            {
                Types = _context.DealTypes.ToList()
            };
            return View("DealForm", viewModel);
        }

        public ActionResult Save(Deal deal)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DealFormViewModel
                {
                    Deal = deal,
                    Types = _context.DealTypes.ToList()
                };

                return View("DealForm", viewModel);
            }
            if (deal.Id == 0)
                _context.Deals.Add(deal);
            else
            {
                var dealInDb = _context.Deals.Single(c => c.Id == deal.Id);

                dealInDb.Name = deal.Name;
            }
            _context.Deals.Add(deal);
            _context.SaveChanges();
            return RedirectToAction("Index", "Deals");

        }

        public ActionResult Edit(int id)
        {
            var deal = _context.Deals.SingleOrDefault(c => c.Id == id);

            if (deal == null)
                HttpNotFound();

            var viewModel = new DealFormViewModel
            {
                Deal = deal,
                
            };

            return View("DealForm", viewModel);
        }

        // GET: Clients
        public ActionResult Index()
        {
            var deals = _context.Deals.ToList(); // differed execution - query is executed when we iterate over object or by calling the ToList methd

            return View(deals);
        }

        public ActionResult Details(int id)
        {
            var deal = _context.Deals.SingleOrDefault(c => c.Id == id);

            if (deal == null)
                return HttpNotFound();

            return View(deal);
        }
    }
}