using BLG4MG_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic
{
    public interface ICustomer
    {
        void Create(Customer item);
        Customer Read(int id);
        IQueryable<Customer> ReadAll();
        void Update(Customer item);
        void Delete(int id);
        public IEnumerable<object> RentTimeByCustomer();
    }
}
