using BLG4MG_HFT_2021222.Models;
using BLG4MG_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic.Classes
{
    class BrandLogic : IBrand
    {
        IRepository<Brand> Repository;

        public BrandLogic(IRepository<Brand> repository)
        {
            this.Repository = repository;
        }

        public void Create(Brand item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetCars(string brand)
        {
            throw new NotImplementedException();
        }

        public Brand Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Brand> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Brand item)
        {
            throw new NotImplementedException();
        }
    }
}
