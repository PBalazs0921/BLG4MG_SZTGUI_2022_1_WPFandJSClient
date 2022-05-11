using BLG4MG_HFT_2021222.Logic;
using BLG4MG_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLG4MG_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomer logic;
        public CustomerController(ICustomer logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Customer value)
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
