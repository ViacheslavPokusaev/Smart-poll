using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerCore.Models;
using ServerCore.Services;

namespace ServerCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        IClient clientService;
        public ClientController(IClient clientService)
        {
            this.clientService = clientService;
        }

        //GET: <controller>
        [HttpGet]
        public List<Client> Get()
        {
            return clientService.GetClients();
        }

        // POST <controller>/signup
        [HttpPost("signup")]
        public int Post(Client client)
        {
            if (client == null) BadRequest();

            return this.clientService.Create(client);
        }

        // POST <controller>/signin
        [HttpPost("signin")]
        public int Login(Client client)
        {
            if (client == null) BadRequest();

            return this.clientService.GetId(client);
        }
    }
}