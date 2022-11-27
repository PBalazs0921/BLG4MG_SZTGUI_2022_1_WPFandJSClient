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
    public class BrandController : ControllerBase
    {
        private readonly IHubContext<SignalRHub> hub;
        IBrand logic;
        public BrandController(IBrand logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.logic.Create(value);
            hub.Clients.All.SendAsync("BrandCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            this.logic.Update(value);
            hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var BrandDeleted = this.logic.Read(id);
            this.logic.Delete(id);
            hub.Clients.All.SendAsync("BrandDeleted", BrandDeleted);
        }
    }
}
