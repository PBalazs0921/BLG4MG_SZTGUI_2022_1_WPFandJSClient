using BLG4MG_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Logic
{
    public interface ICar
    {
        void Create(Car item);
        Car Read(int id);
        IQueryable<Car> ReadAll();
        void Update(Car item);
        void Delete(int id);
        public IEnumerable<object> HowManyModelsPerBrand();


    }
}
