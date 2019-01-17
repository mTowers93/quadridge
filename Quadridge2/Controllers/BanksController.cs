using Quadridge2.Models;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class BanksController : Controller
    {
        private ApplicationDbContext _context;

        public BanksController()
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
            var banks = _context.Banks.ToList();
            return View(banks);
        }

        public ActionResult New()
        {
            var viewModel = new BanksFormViewModel
            {
                Provinces = _context.Provinces.ToList(),
                Countries = _context.Countries.ToList()
            };

            return View("BankForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Bank bank)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BanksFormViewModel
                {
                    Bank = bank,
                    Provinces = _context.Provinces.ToList(),
                    Countries = _context.Countries.ToList()
                };

                return View("BankForm", viewModel);
            }
            if (bank.Id == 0)
                _context.Banks.Add(bank);
            else
            {
                var bankInDb = _context.Banks.Single(c => c.Id == bank.Id);

                bankInDb.Name = bank.Name;
            }
            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Banks");
            _context.SaveChanges();
            return Json(new { Url = redirectUrl});

        }

        public ActionResult Delete(int? id)
        {           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };

            var bankInDb = _context.Banks.SingleOrDefault(b => b.Id == id);

            if (bankInDb == null)
            {
                return HttpNotFound();
            }
            _context.Banks.Remove(bankInDb);
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Banks");
            _context.SaveChanges();
            return Json(new { Url = redirectUrl });
        }
    }
}