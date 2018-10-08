using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quadridge2.Models;
using AutoMapper;
using Quadridge2.Dtos;

namespace Quadridge2.Controllers.Api
{
    public class DealsController : ApiController
    {
        private ApplicationDbContext _context;

        public DealsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Deals
        public IHttpActionResult GetDeals()
        {
            var dealDtos = _context.Deals.ToList().Select(Mapper.Map<Deal, DealDto>);

            return Ok(dealDtos);
        }

        //GET /api/Deals/1
        public IHttpActionResult GetDeal(int id)
        {
            var deal = _context.Deals.SingleOrDefault(c => c.Id == id);

            if (deal == null)
                NotFound();

            return Ok(Mapper.Map<Deal, DealDto>(deal));
        }

        //POST /api/Deals
        [HttpPost]
        public IHttpActionResult CreateDeal(DealDto dealDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var deal = Mapper.Map<DealDto, Deal>(dealDto);

            _context.Deals.Add(deal);
            _context.SaveChanges();

            dealDto.Id = deal.Id;

            return Created(new Uri(Request.RequestUri + "/" + deal.Id), dealDto);
        }

        // PUT /api/Deals/1
        [HttpPut]
        public IHttpActionResult UpdateDeal(int id, DealDto dealDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var dealInDb = _context.Deals.SingleOrDefault(c => c.Id == id);

            if (dealInDb == null)
                NotFound();

            Mapper.Map(dealDto, dealInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDeal(int id)
        {
            var dealInDb = _context.Deals.SingleOrDefault(c => c.Id == id);

            if (dealInDb == null)
                NotFound();

            _context.Deals.Remove(dealInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
