using BLG4MG_HFT_2021222.Models;
using BLG4MG_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic
{
    public class CustomerLogic : ICustomer
    {
        IRepository<Customer> Repository;

        public CustomerLogic(IRepository<Customer> repository)
        {
            this.Repository = repository;
        }

        //CRUD
        public void Create(Customer item)
        {
            if (item.Name == null)
            {
                throw new ArgumentException("Customer name cant be empty");
            }
            else
            {
                this.Repository.Create(item);
            }
        }


        public Customer Read(int id)
        {
            var read = this.Repository.Read(id);
            if (read == null)
            {
                throw new ArgumentException("Customer does not exist in database");
            }
            else
            {
                return read;
            }
        }

        public IQueryable<Customer> ReadAll()
        {
            return this.Repository.ReadAll();
        }

        public void Update(Customer item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

    }
}
