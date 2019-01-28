using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quadridge2.ViewModels.Companies;
using System.Net;

namespace Quadridge2.Controllers
{
    public class CompaniesController : Controller
    {
        private ApplicationDbContext _context;

        public CompaniesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Companies
        public ActionResult Index()
        {
            var companies = _context.Companies.ToList();
            return View(companies);
        }

        public ActionResult New()
        {
            var viewModel = new CompanyFormViewModel
            {
                Services = _context.Services.ToList(),
                Trusts = _context.Trusts.ToList(),
                BillingBases = _context.BillingBases.ToList(),
                FeeTypes = _context.FeeTypes.ToList(),
                Structures = _context.Structures.ToList()
            };
            return View("CompanyForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Company company, List<int> services)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CompanyFormViewModel
                {
                    Company = company,
                        Services = _context.Services.ToList(),
                        Trusts = _context.Trusts.ToList(),
                        FeeTypes = _context.FeeTypes.ToList(),
                        BillingBases = _context.BillingBases.ToList(),
                        Structures = _context.Structures.ToList()
                };

                return View("CompanyForm", viewModel);
            }
            if (company.Id == 0)
            {
                _context.Companies.Add(company);
                _context.SaveChanges();

            }  
            else
            {
                var companyInDb = _context.Companies.Single(c => c.Id == company.Id);

                companyInDb.Name = company.Name;
            }

            if (services.Count() > 0)
            {
                for (int i = 0; i < services.Count(); i++)
                {
                    var serviceId = services[i];
                    var addService = new CompanyService()
                    {
                        Service = _context.Services.Single(s => s.Id == serviceId),
                        ServiceId = serviceId,
                        Company = company,
                        CompanyId = company.Id
                    };
                    _context.CompanyServices.Add(addService);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Companies");

        }

        public ActionResult Details(int id)
        {
            var company = _context.Companies.Single(c => c.Id == id);
            if (company == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var viewModel = new CompanyDetailsViewModel()
            {
                Company = company,
                Contacts = _context.Contacts.ToList()
            };
            ViewBag.Title = "Details for " + company.Name;
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var company = _context.Companies.Single(c => c.Id == id);
            if (company == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var viewModel = new CompanyFormViewModel()
            {
                Company = company,
                Services = _context.Services.ToList(),
                Trusts = _context.Trusts.ToList(),
                FeeTypes = _context.FeeTypes.ToList(),
                BillingBases = _context.BillingBases.ToList(),
                Structures = _context.Structures.ToList()
            };

            return View("CompanyForm", viewModel);
        }

        public ActionResult AssignContacts(int id, List<int> contacts)
        {
            if (contacts.Count() > 0)
            {
                for (int i = 0; i < contacts.Count(); i++)
                {
                    var contactId = contacts[i];
                    var addContact = new CompanyContact()
                    {
                        ContactId = contactId,
                        CompanyId = id
                    };
                    _context.CompanyContacts.Add(addContact);
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Details", new { id });
        }

        public ActionResult RemoveContact(int? id, int? cid)
        {
            if (cid == null || id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var companyContact = _context.CompanyContacts.Single(c => c.CompanyId == id && c.ContactId == cid);
            if (companyContact == null)
                return HttpNotFound();

            _context.CompanyContacts.Remove(companyContact);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id });
        }
    }
}