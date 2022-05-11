using BLG4MG_HFT_2021222.Models;
using BLG4MG_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic
{
    public class BrandLogic : IBrand
    {
        IRepository<Brand> Repository;

        public BrandLogic(IRepository<Brand> repository)
        {
            this.Repository = repository;
        }


        //CRUD 
        public void Create(Brand item)
        {
            if (item.BrandName == null)
            {
                throw new ArgumentException("Brand name cant be empty");
            }
            else
            {
                this.Repository.Create(item);
            }
        }



        public Brand Read(int id)
        {
            var Brand = this.Repository.Read(id);
            if (Brand == null)
            {
                throw new ArgumentException("Brand does not exits in database");
            }
            else
            {
                return Brand;
            }
        }

        public IQueryable<Brand> ReadAll()
        {
            return this.Repository.ReadAll();
        }

        public void Update(Brand item)
        {
            this.Repository.Update(item);
        }


        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
        //NON-CRUD




    }
}
