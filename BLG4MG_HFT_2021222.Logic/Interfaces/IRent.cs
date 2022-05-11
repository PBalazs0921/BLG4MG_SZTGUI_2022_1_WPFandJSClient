using BLG4MG_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic
{
    public interface IRent
    {
        void Create(Rent item);
        Rent Read(int id);
        IQueryable<Rent> ReadAll();
        void Update(Rent item);
        void Delete(int id);
    }
}
