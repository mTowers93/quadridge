using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quadridge2.Models;
using Quadridge2.ViewModels;

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

        public ActionResult New()
        {
            var viewModel = new ContactFormViewModel
            {
                Clients = _context.Clients.ToList()
            };
            return View("ContactForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ContactFormViewModel
                {
                    Contact = contact,
                    Clients = _context.Clients.ToList()
                };

                return View("ContactForm", viewModel);
            }
            if (contact.Id == 0)
                _context.Contacts.Add(contact);
            else
            {
                var contactInDb = _context.Contacts.Single(c => c.Id == contact.Id);

                contactInDb.ClientId = contact.ClientId;
                contactInDb.Firstname = contact.Firstname;
                contactInDb.Surname = contact.Surname;
                contactInDb.Email = contact.Email;
                contactInDb.ContactNo = contact.ContactNo;

                if (!String.IsNullOrWhiteSpace(contact.AltContactNo))
                    contactInDb.AltContactNo = contact.AltContactNo;

               
            }
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index", "Contacts");

        }
    }
}