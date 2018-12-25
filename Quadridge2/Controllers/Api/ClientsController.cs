using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Quadridge2.Models;
using Quadridge2.Dtos;
using AutoMapper;

namespace Quadridge2.Controllers.Api
{
    public class ClientsController : ApiController
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

        //GET /api/clients
        public IHttpActionResult GetClients()
        {
            var customerDtos = _context.Clients.ToList().Select(Mapper.Map<Client, ClientDto>);

            return Ok(customerDtos);
        }

        //GET /api/clients/1
        public IHttpActionResult GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                NotFound();

            return Ok(Mapper.Map<Client, ClientDto>(client));
        }

        //POST /api/clients
        [HttpPost]
        public IHttpActionResult CreateClient(ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var client = Mapper.Map<ClientDto, Client>(clientDto);

            _context.Clients.Add(client);
            _context.SaveChanges();

            clientDto.Id = client.Id;

            return Created(new Uri(Request.RequestUri + "/" + client.Id), clientDto);
        }

        // PUT /api/clients/1
        [HttpPut]
        public IHttpActionResult UpdateClient(int id, ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                NotFound();

            Mapper.Map(clientDto, clientInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteClient(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                NotFound();

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
