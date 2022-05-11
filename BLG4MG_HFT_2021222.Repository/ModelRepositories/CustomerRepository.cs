using BLG4MG_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Repository.ModelRepositories
{
    class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(RentalDbContext context) : base(context)
        {
        }

        public override Customer Read(int id)
        {
            return context.Customers.FirstOrDefault(t => t.id == id);
        }

        public override void Update(Customer item)
        {
            var old = Read(item.id);
            foreach (var prop in item.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            context.SaveChanges();
        }
    }
}
