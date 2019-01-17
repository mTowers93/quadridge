using Quadridge2.Models;
using Quadridge2.Models.Contacts;
using Quadridge2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return View(contact);
        }

        public ActionResult New()
        {
            var viewModel = new ContactFormViewModel
            {
                Banks = _context.Banks.ToList(),
                LawFirms = _context.LawFirms.ToList(),
                Standalones = _context.Standalones.ToList(),
                IsBank = false,
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
                if (viewModel.IsBank)
                {
                    var bankContact = new BankContact()
                    {
                        BankId = viewModel.RelationId,
                        Bank = _context.Banks.Single(b => b.Id == viewModel.RelationId),
                        ContactId = contactId,
                        Contact = viewModel.Contact
                    };
                    _context.BankContacts.Add(bankContact);
                }
                else if (viewModel.IsLawFirm)
                {
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
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Contacts");

        }
    }
}