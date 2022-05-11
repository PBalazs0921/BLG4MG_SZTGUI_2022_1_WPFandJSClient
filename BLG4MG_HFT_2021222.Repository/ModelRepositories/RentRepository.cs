using BLG4MG_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Repository
{
    public class RentRepository : Repository<Rent>, IRepository<Rent>
    {
        public RentRepository(RentalDbContext context) : base(context)
        {
        }

        public override Rent Read(int id)
        {
            return context.Rents.FirstOrDefault(t => t.id == id);
        }

        public override void Update(Rent item)
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
