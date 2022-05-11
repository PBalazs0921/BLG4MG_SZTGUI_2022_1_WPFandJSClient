
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Repository
{
    public abstract class Repository<T>: IRepository<T> where T: class
    {
        protected RentalDbContext context;

        public Repository(RentalDbContext context)
        {
            this.context = context;
        }

        public void Create(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return context.Set<T>();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Read(id));
            context.SaveChanges();
        }

        public abstract T Read(int id);

        public abstract void Update(T item);
    }
}
