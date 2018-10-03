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

        //GET /api/clients
        public IEnumerable<ClientDto> GetClients()
        {
            return _context.Clients.ToList().Select(Mapper.Map<Client, ClientDto>);
        }

        //GET /api/clients/1
        public ClientDto GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (client == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Client, ClientDto>(client);
        }

        //POST /api/clients
        [HttpPost]
        public ClientDto CreateClient(ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var client = Mapper.Map<ClientDto, Client>(clientDto);

            _context.Clients.Add(client);
            _context.SaveChanges();

            clientDto.Id = client.Id;

            return clientDto;
        }

        // PUT /api/clients/1
        [HttpPut]
        public void UpdateClient(int id, ClientDto clientDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(clientDto, clientInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteClient(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(c => c.Id == id);

            if (clientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();
        }
    }
}
