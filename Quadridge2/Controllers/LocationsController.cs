using Quadridge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quadridge2.ViewModels;

namespace Quadridge2.Controllers
{
  public class LocationsController : Controller
  {
    private ApplicationDbContext _context = new ApplicationDbContext();

    public LocationsController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }
    // GET: Locations
    public ActionResult Index()
    {
      var Locations = _context.Locations.ToList();
      return View(Locations);
    }
    public ActionResult Edit(int id)
    {
      var location = _context.Locations.FirstOrDefault(x => x.Id == id);
      return View();
    }
    public ActionResult New()
    {
      var locationViewModel = new LocationViewModel
      {
        Location = new Location() { CountryId = 200 },
        Provinces = _context.Provinces.ToList(),
        Countries = _context.Countries.ToList(),
        Institutes = _context.Institutes.ToList()
      };
      return View("LocationForm", locationViewModel);
    }

    public ActionResult Save(Location location)
    {
      if (!ModelState.IsValid)
      {
        var viewModel = new LocationViewModel
        {
          Location = location,
          Provinces = _context.Provinces.ToList(),
          Countries = _context.Countries.ToList()
        };

        return View("LocationForm", viewModel);
      }
      if (location.Id == 0)
        _context.Locations.Add(location);
      else
      {
        var locationInDb = _context.Locations.Single(l => l.Id == location.Id);
        locationInDb.Name = location.Name;
        locationInDb.FirstLine = location.FirstLine;
        locationInDb.SecondLine = location.SecondLine;
        locationInDb.City = location.City;
        locationInDb.Suburb = location.Suburb;
        locationInDb.ProvinceId = location.ProvinceId;
        locationInDb.CountryId = location.CountryId;
      }
      _context.SaveChanges();
      var locations = _context.Locations.ToList();
      return View("Index", locations);
    }

    public ActionResult Delete(int id)
    {
      var locationInDb = _context.Locations.SingleOrDefault(x => x.Id == id);
      if (locationInDb == null) return new HttpNotFoundResult();
      _context.Locations.Remove(locationInDb);
      _context.SaveChanges();
      var locations = _context.Locations.ToList();
      return View("Index", locations);
    }
  }
}