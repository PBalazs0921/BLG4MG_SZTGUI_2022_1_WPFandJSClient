using BLG4MG_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Repository.ModelRepositories
{
    class CarRepository : Repository<Car>, IRepository<Car>
    {
        public CarRepository(RentalDbContext context) : base(context)
        {
        }

        public override Car Read(int id)
        {
            return context.Cars.FirstOrDefault(t => t.id == id);
        }

        public override void Update(Car item)
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
