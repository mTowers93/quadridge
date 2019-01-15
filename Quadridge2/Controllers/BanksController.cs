using Quadridge2.Models;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
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
        [ValidateAntiForgeryToken]
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
                bankInDb.FirstAddressLine = bank.FirstAddressLine;
                bankInDb.SecondAddressLine = bank.SecondAddressLine;
                bankInDb.Suburb = bank.Suburb;
                bankInDb.City = bank.City;
                bankInDb.Zip = bank.Zip;
                bankInDb.ProvinceId = bank.ProvinceId;
                bankInDb.CountryId = bank.CountryId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Banks");

        }
    }
}