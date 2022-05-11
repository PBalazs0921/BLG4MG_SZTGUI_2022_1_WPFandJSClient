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
using System.Reflection;

namespace BLG4MG_HFT_2021222.Test
{
    class CarTest
    {
        CarLogic logic;
        Mock<IRepository<Car>> mockCarRepo;
        Brand BMW = new Brand() { BrandName = "BMW", BrandId = 1 };
        [SetUp]
        public void Init()
        {

            mockCarRepo = new Mock<IRepository<Car>>();
            mockCarRepo.Setup(x => x.ReadAll()).Returns(new List<Car>()
            {
                new Car() { BrandId=1,Model="E46",Cost=1000,id=1,Brand=BMW},
                new Car() { BrandId=1,Model="E46",Cost=1000,id=2,Brand=BMW},
        }.AsQueryable());
            logic = new CarLogic(mockCarRepo.Object);
        }

        [Test]
        public void CreateRenterTest()
        {
            //ACT
            var car = new Car() { BrandId = 1, Model = "E26", Cost = 1000, id = 1 ,Brand = BMW };

            logic.Create(car);

            //ASSERT
            mockCarRepo.Verify(r => r.Create(car), Times.Once());
        }

        [Test]
        public void HowManyModelsPerBrandTest()
        {
            var test = this.logic.HowManyModelsPerBrand();
            
            Assert.That(test.First().GetType().GetProperty("CarNum").GetValue(test.First(),null), Is.EqualTo(2));   
        }
    }
}
