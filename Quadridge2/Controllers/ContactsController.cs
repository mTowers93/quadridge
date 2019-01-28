using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quadridge2.Controllers
{
    public class ContactsController : Controller
    {
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Contacts
        public ActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public ActionResult Details(int id)
        {
            var contact = _context.Contacts.SingleOrDefault(c => c.Id == id);
            if (contact == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            contact.Country = _context.Countries.Single(c => c.Id == contact.CountryId);
            contact.Province = _context.Provinces.Single(p => p.Id == contact.ProvinceId);
            return View(contact);
        }

        public ActionResult New()
        {
            var viewModel = new ContactFormViewModel
            {
                FinancialInstitutions = _context.FinancialInstitutions.ToList(),
                LawFirms = _context.LawFirms.ToList(),
                Standalones = _context.Standalones.ToList(),
                Provinces = _context.Provinces.ToList(),
                Countries = _context.Countries.ToList(),
                IsFinancialInstitution = false,
                IsLawFirm = false,
                IsStandalone = false
            };

            return View("ContactForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ContactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactForm", viewModel);
            }
            if (viewModel.Contact.Id == 0)
            {
                _context.Contacts.Add(viewModel.Contact);
                _context.SaveChanges();

                var contactId = viewModel.Contact.Id;
                var contactInDb = _context.Contacts.Single(c => c.Id == contactId);
                if (viewModel.IsFinancialInstitution)
                {
                    contactInDb.IsFinancialContact = true;
                    contactInDb.IsLawFirmContact = false;
                    contactInDb.IsStandalone = false;
                    var financialInstitutionContact = new FinancialInstitutionContact()
                    {
                        FinancialInstitutionId = viewModel.RelationId,
                        FinancialInstitution = _context.FinancialInstitutions.Single(b => b.Id == viewModel.RelationId),
                        ContactId = contactId,
                        Contact = viewModel.Contact
                    };
                    _context.FinancialInstitutionContacts.Add(financialInstitutionContact);
                }
                else if (viewModel.IsLawFirm)
                {
                    contactInDb.IsFinancialContact = false;
                    contactInDb.IsLawFirmContact = true;
                    contactInDb.IsStandalone = false;
                    var lawFirmContact = new LawFirmContact()
                    {
                        LawFirmId = viewModel.RelationId,
                        LawFirm = _context.LawFirms.Single(l => l.Id == viewModel.RelationId),
                        ContactId = contactId,
                        Contact = viewModel.Contact,

                    };
                    _context.LawFirmContacts.Add(lawFirmContact);
                }
                else if (viewModel.IsStandalone)
                {
                    contactInDb.IsFinancialContact = false;
                    contactInDb.IsLawFirmContact = false;
                    contactInDb.IsStandalone = true;
                    var standaloneContact = new StandaloneContact()
                    {
                        StandAloneId = viewModel.RelationId,
                        Standalone = _context.Standalones.Single(s => s.Id == viewModel.RelationId),
                        Contact = viewModel.Contact,
                        ContactId = contactId
                    };
                    _context.StandaloneContacts.Add(standaloneContact);
                }
            }
                
            else
            {
                var contactInDb = _context.Contacts.Single(c => c.Id == viewModel.Contact.Id);

                contactInDb.Firstname = viewModel.Contact.Firstname;
                contactInDb.Surname = viewModel.Contact.Surname;
                contactInDb.Email = viewModel.Contact.Email;
                contactInDb.ContactNo = viewModel.Contact.ContactNo;

                
                if (!String.IsNullOrWhiteSpace(viewModel.Contact.AltContactNo))
                    contactInDb.AltContactNo = viewModel.Contact.AltContactNo;

                contactInDb.FirstAddressLine = viewModel.Contact.FirstAddressLine;
                contactInDb.SecondAddressLine = viewModel.Contact.SecondAddressLine;
                contactInDb.Suburb = viewModel.Contact.Suburb;
                contactInDb.City = viewModel.Contact.City;
                contactInDb.Zip = viewModel.Contact.Zip;
                contactInDb.ProvinceId = viewModel.Contact.ProvinceId;
                contactInDb.CountryId = viewModel.Contact.CountryId;
                contactInDb.Birthday = viewModel.Contact.Birthday;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Contacts");

        }

        public ActionResult Edit(int id)
        {
            var contact = _context.Contacts.Single(c => c.Id == id);
            if (contact == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var viewModel = new ContactFormViewModel()
            {
                Contact = contact,
                FinancialInstitutions = _context.FinancialInstitutions.ToList(),
                LawFirms = _context.LawFirms.ToList(),
                Standalones = _context.Standalones.ToList(),
                Provinces = _context.Provinces.ToList(),
                Countries = _context.Countries.ToList()

            };

            return View("ContactForm", viewModel);
        }
    }
}