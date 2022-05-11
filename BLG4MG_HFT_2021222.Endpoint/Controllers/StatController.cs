using BLG4MG_HFT_2021222.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES8NPY_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICar carLogic;
        IBrand brandLogic;
        ICustomer renterLogic;
        IRent rentingLogic;

        public StatController(ICar carLogic, IBrand brandLogic, ICustomer customer, IRent rentingLogic)
        {
            this.carLogic = carLogic;
            this.brandLogic = brandLogic;
            this.renterLogic = customer;
            this.rentingLogic = rentingLogic;
        }

        //[HttpGet("{year}")]
        [HttpGet]
        public IEnumerable<object> HowManyTimesRented()
        {
            return this.carLogic.HowManyTimesRented();
        }
        [HttpGet]
        public IEnumerable<object> RentTimeByCustomer()
        {
            return this.renterLogic.RentTimeByCustomer();
        }
    }
}
