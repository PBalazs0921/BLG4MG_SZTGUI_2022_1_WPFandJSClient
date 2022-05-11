using BLG4MG_HFT_2021222.Logic;
using BLG4MG_HFT_2021222.Models;
using BLG4MG_HFT_2021222.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Test
{
    class CarTest
    {
        CarLogic logic;
        Mock<IRepository<Car>> mockCarRepo;
        [SetUp]
        public void Init()
        {
            mockCarRepo = new Mock<IRepository<Car>>();
            mockCarRepo.Setup(x => x.ReadAll()).Returns(new List<Car>()
            {

            }.AsQueryable());
            logic = new CarLogic(mockCarRepo.Object);
        }

        [Test]
        public void CreateRenterTest()
        {
            //ACT
            var car = new Car() { BrandId=1,Model="BMW",Cost=1000,id=1};
            logic.Create(car);

            //ASSERT
            mockCarRepo.Verify(r => r.Create(car), Times.Once());
        }
    }
}
