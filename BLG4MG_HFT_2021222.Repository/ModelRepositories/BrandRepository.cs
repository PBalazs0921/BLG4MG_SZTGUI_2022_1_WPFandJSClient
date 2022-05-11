using BLG4MG_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Repository
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(RentalDbContext context) : base(context)
        {
        }

        public override Brand Read(int id)
        {
            return context.Brands.FirstOrDefault(t=>t.BrandId==id);
        }

        public override void Update(Brand item)
        {
            var old = Read(item.BrandId);
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