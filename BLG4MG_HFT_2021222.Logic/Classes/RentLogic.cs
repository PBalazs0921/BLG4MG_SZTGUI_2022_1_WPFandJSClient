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



    }
}
