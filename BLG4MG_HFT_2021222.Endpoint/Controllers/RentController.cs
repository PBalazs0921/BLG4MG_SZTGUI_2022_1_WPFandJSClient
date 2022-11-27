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
    public class RentController : ControllerBase
    {
        private readonly IHubContext<SignalRHub> hub;
        IRent logic;
        public RentController(IRent logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Rent> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Rent Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Rent value)
        {
            this.logic.Create(value);
            hub.Clients.All.SendAsync("RentCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Rent value)
        {
            this.logic.Update(value);
            hub.Clients.All.SendAsync("RentUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var Delete = this.logic.Read(id);
            this.logic.Delete(id);
            hub.Clients.All.SendAsync("RentDeleted", Delete);
        }
    }
}
