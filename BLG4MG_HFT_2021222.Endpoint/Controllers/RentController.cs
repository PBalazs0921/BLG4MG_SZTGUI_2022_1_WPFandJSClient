using BLG4MG_HFT_2021222.Logic;
using BLG4MG_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLG4MG_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        IRent logic;
        public RentController(IRent logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Rent value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
