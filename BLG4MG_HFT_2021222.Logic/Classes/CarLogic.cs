using BLG4MG_HFT_2021222.Models;
using BLG4MG_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic
{
    public class CarLogic : ICar
    {
        IRepository<Car> Repository;
        public CarLogic(IRepository<Car> repo)
        {
            this.Repository = repo;
        }


        //CRUD
        public void Create(Car item)
        {
            if (item.Model == null)
            {
                throw new ArgumentException("Model name cant be empty");
            }
            else
            {
                this.Repository.Create(item);
            }
        }


        public Car Read(int id)
        {
            var read = this.Repository.Read(id);
            if (read == null)
            {
                throw new ArgumentException("Car does not exist in database");
            }
            else
            {
                return read;
            }
        }

        public IQueryable<Car> ReadAll()
        {
            return this.Repository.ReadAll();
        }

        public void Update(Car item)
        {
            this.Repository.Update(item);
        }


        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }


        //NON CRUD
        public IEnumerable<object> HowManyModelsPerBrand()
        {
            return from x in Repository.ReadAll()
                   group x by x.Brand.BrandName into g
                   select new 
                   {
                       Brand = g.Key,
                       CarNum = g.Count()
                   };
        }











    }
}
