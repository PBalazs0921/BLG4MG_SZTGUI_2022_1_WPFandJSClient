using BLG4MG_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic
{
    public interface IBrand
    {
        void Create(Brand item);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand item);
        void Delete(int id);
    }
}
