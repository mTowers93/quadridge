using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quadridge2.ViewModels.Clients;

namespace Quadridge2.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new ClientFormViewModel
            {
                Provinces = _context.Provinces.ToList(),
                Countries = _context.Countries.ToList()
            };
            return View("ClientForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Client client)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClientFormViewModel
                {
                    Client = client,
                    Provinces = _context.Provinces.ToList(),
                    Countries = _context.Countries.ToList()
                };

                return View("ClientForm", viewModel);
            }
            if (client.Id == 0)
                _context.Clients.Add(client);
            else
            {
                var clientInDb = _context.Clients.Single(c => c.Id == client.Id);

                clientInDb.Name = client.Name;
                clientInDb.FirstAddressLine = client.FirstAddressLine;
                clientInDb.SecondAddressLine = client.SecondAddressLine;
                clientInDb.Suburb = client.Suburb;
                clientInDb.City = client.City;
                clientInDb.Zip = client.Zip;
                clientInDb.ProvinceId = client.ProvinceId;
                clientInDb.CountryId = client.CountryId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Clients");

        }

        public ActionResult Edit(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                HttpNotFound();

            var viewModel = new ClientFormViewModel
            {
                Client = client,
                Provinces = _context.Provinces.ToList(),
                Countries = _context.Countries.ToList()
            };

            return View("ClientForm", viewModel);
        }

        // GET: Clients
        public ActionResult Index()
        {
            var clients = _context.Clients.ToList(); // differed execution - query is executed when we iterate over object or by calling the ToList methd

            return View(clients);
        }

        public ActionResult Details(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            var viewmodel = new ClientDetailsViewModel
            {
                Client = client,
                Comments = _context.Comments.Where(c => c.ClientId == client.Id).ToList(),
                Contacts = _context.Contacts.Where(c => c.EntityId == client.Id).ToList(),
                Deals = _context.Deals.Where(c => c.ClientId == client.Id).ToList(),
                Provinces = _context.Provinces.ToList(),
                Countries = _context.Countries.ToList(),
                Companies = _context.Companies.ToList()
            };

            if (client == null)
                return HttpNotFound();

            return View(viewmodel);
        }

        public ActionResult SaveComment(Comment comment)
        {
            if (comment.Id == 0)
                _context.Comments.Add(comment);
            else
            {
                var commentInDb = _context.Comments.SingleOrDefault(c => c.Id == comment.Id);
                commentInDb.CommentString = comment.CommentString;
            }

            _context.SaveChanges();
            return RedirectToAction("Details/" + comment.ClientId, "Clients");
        }

    }
}