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
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LawFirms
        public ActionResult Index()
        {
            var lawFirms = db.LawFirms.Include(l => l.Country).Include(l => l.Province);
            return View(lawFirms.ToList());
        }

        // GET: LawFirms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawFirm lawFirm = db.LawFirms.Find(id);
            if (lawFirm == null)
            {
                return HttpNotFound();
            }
            return View(lawFirm);
        }

        // GET: LawFirms/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "code");
            ViewBag.ProvinceId = new SelectList(db.Provinces, "Id", "Code");
            return View();
        }

        // POST: LawFirms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FirstAddressLine,SecondAddressLine,Suburb,City,Zip,ProvinceId,CountryId")] LawFirm lawFirm)
        {
            if (ModelState.IsValid)
            {
                db.LawFirms.Add(lawFirm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "Id", "code", lawFirm.CountryId);
            ViewBag.ProvinceId = new SelectList(db.Provinces, "Id", "Code", lawFirm.ProvinceId);
            return View(lawFirm);
        }

        // GET: LawFirms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawFirm lawFirm = db.LawFirms.Find(id);
            if (lawFirm == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "code", lawFirm.CountryId);
            ViewBag.ProvinceId = new SelectList(db.Provinces, "Id", "Code", lawFirm.ProvinceId);
            return View(lawFirm);
        }

        // POST: LawFirms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FirstAddressLine,SecondAddressLine,Suburb,City,Zip,ProvinceId,CountryId")] LawFirm lawFirm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lawFirm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "code", lawFirm.CountryId);
            ViewBag.ProvinceId = new SelectList(db.Provinces, "Id", "Code", lawFirm.ProvinceId);
            return View(lawFirm);
        }

        // GET: LawFirms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LawFirm lawFirm = db.LawFirms.Find(id);
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
            LawFirm lawFirm = db.LawFirms.Find(id);
            db.LawFirms.Remove(lawFirm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
