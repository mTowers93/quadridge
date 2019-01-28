using Quadridge2.Models;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
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

        public ActionResult Save(Trust trust, List<int> services)
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
            {
                _context.Trusts.Add(trust);
                _context.SaveChanges();
            }
                
            
            else
            {
                var trustInDb = _context.Trusts.Single(t => t.Id == trust.Id);
                trustInDb.Name = trust.Name;
                trustInDb.StructureId = trust.StructureId;
            }

            if (services.Count() > 0)
            {
                for (int i = 0; i < services.Count(); i++)
                {
                    var serviceId = services[i];
                    var addTrust = new TrustService()
                    {
                        Service = _context.Services.Single(s => s.Id == serviceId),
                        ServiceId = serviceId,
                        Trust = trust,
                        TrustId = trust.Id
                    };
                    _context.TrustServices.Add(addTrust);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Trusts");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };

            var trustInDb = _context.Trusts.SingleOrDefault(b => b.Id == id);

            if (trustInDb == null)
            {
                return HttpNotFound();
            }
            _context.Trusts.Remove(trustInDb);
            _context.SaveChanges();

            var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Trusts");
            _context.SaveChanges();
            return Json(new { Url = redirectUrl });
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };

            var trust = _context.Trusts
                        .Include(t => t.Companies)
                        .Include(t => t.TrustServices)
                        .Where(t => t.Id == id)
                        .Single();

            if( trust == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(trust);
        }
    }
}