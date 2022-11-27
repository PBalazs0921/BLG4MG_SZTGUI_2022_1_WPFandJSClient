using BLG4MG_HFT_2021222.Logic;
using BLG4MG_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLG4MG_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IHubContext<SignalRHub> hub;
        ICustomer logic;
        public CustomerController(ICustomer logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Customer> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Customer value)
        {
            this.logic.Create(value);
            hub.Clients.All.SendAsync("CustomerCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Customer value)
        {
            this.logic.Update(value);
            hub.Clients.All.SendAsync("CustomerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Delete = this.logic.Read(id);
            this.logic.Delete(id);
            hub.Clients.All.SendAsync("CustomerDeleted", Delete);
        }
    }
}
