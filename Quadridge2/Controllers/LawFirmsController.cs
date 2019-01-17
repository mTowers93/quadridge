using Quadridge2.ViewModels.LawFirms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quadridge2.Models;

namespace Quadridge2.Controllers
{
    public class LawFirmsController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public LawFirmsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: LawFirms
        public ActionResult Index()
        {
            var lawFirms = _context.LawFirms.ToList();
            return View(lawFirms);
        }

        public ActionResult New()
        {
            var viewModel = new LawFirmFormViewModel()
            {
                Provinces = _context.Provinces.ToList(),
                Countries = _context.Countries.ToList()
            };
            return View("LawFirmForm", viewModel);
        }

        public ActionResult Save(LawFirm lawFirm)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LawFirmFormViewModel
                {
                    LawFirm = lawFirm,
                    Provinces = _context.Provinces.ToList(),
                    Countries = _context.Countries.ToList()
                };

                return View("BankForm", viewModel);
            }
            if (lawFirm.Id == 0)
                _context.LawFirms.Add(lawFirm);
            else
            {
                var lawFirmInDb = _context.LawFirms.Single(l => l.Id == lawFirm.Id);
                lawFirmInDb.Name = lawFirm.Name;
                lawFirmInDb.FirstAddressLine = lawFirm.FirstAddressLine;
                lawFirmInDb.SecondAddressLine = lawFirm.SecondAddressLine;
                lawFirmInDb.Suburb = lawFirm.Suburb;
                lawFirmInDb.City = lawFirm.City;
                lawFirmInDb.Zip = lawFirm.Zip;
                lawFirmInDb.ProvinceId = lawFirm.ProvinceId;
                lawFirmInDb.CountryId = lawFirm.CountryId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "LawFirms");
        }

        // GET: LawFirms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawFirm lawFirm = _context.LawFirms.Find(id);
            if (lawFirm == null)
            {
                return HttpNotFound();
            }
            return View(lawFirm);
        }

        // GET: LawFirms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawFirm lawFirm = _context.LawFirms.Find(id);
            if (lawFirm == null)
            {
                return HttpNotFound();
            }
            return View(lawFirm);
        }

        // POST: LawFirms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LawFirm lawFirm = _context.LawFirms.Find(id);
            _context.LawFirms.Remove(lawFirm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
