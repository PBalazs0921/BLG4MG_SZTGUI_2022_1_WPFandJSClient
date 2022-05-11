using BLG4MG_HFT_2021222.Models;
using BLG4MG_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic
{
    public class RentLogic : IRent
    {
        IRepository<Rent> Repository;

        public RentLogic(IRepository<Rent> repository)
        {
            Repository = repository;
        }


        //CRUD
        public void Create(Rent item)
        {
            this.Repository.Create(item);

        }


        public Rent Read(int id)
        {
            var read = this.Repository.Read(id);
            if (read == null)
            {
                throw new ArgumentException("Rent entry by this ID does not exist in database");
            }
            else
            {
                return read;
            }
        }

        public IQueryable<Rent> ReadAll()
        {
            return this.Repository.ReadAll();
        }

        public void Update(Rent item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        //NON CRUD

        //KI hanyszor kölcsönzött
        public IEnumerable<object> HowManyTimesRentedACar()
        {
            return from x in Repository.ReadAll()
                   group x by x.car.Model into g
                   select new { Model = g.Key, Count = g.Count() };

        }

        //KI hány adott markat kölcsönzött
        public IEnumerable<object> HowManyBrandRentedByPersons(string model)
        {
            return from x in Repository.ReadAll()
                   where x.car.Model.Equals(model)
                   group x by x.customer.Name into g
                   select new { Name = g.Key, Count = g.Count() };
        }



        //KI hány napot kölcsönzött
        public IEnumerable<object> RentTimeByCustomer()
        {
            return from x in Repository.ReadAll()
                   group x by x.customer.Name into g
                   select new
                   {
                       Name = g.Key,
                       RentedDays = g.Sum(t=> t.end.Subtract(t.begin).TotalDays)
                   };
        }


        //Adott napon hány autót kölcsönöztek

        public IEnumerable<object> RentsByDay()
        {
            return from x in Repository.ReadAll()
                   group x by x.begin into g
                   select new
                   {
                       Date = g.Key,
                       RentsToday = g.Count()
                   };
        }

    }
}
