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
    class RentTest
    {
        RentLogic logic;
        Mock<IRepository<Rent>> mockRentRepo;

        [SetUp]
        public void Init()
        {
            var c1=new Customer() { id = 1, Name = "Customer 1" };
            var car1 = new Car() { BrandId = 1, Model = "E26", Cost = 1000, id = 1};
            mockRentRepo = new Mock<IRepository<Rent>>();
            mockRentRepo.Setup(x => x.ReadAll()).Returns(new List<Rent>()
            {
                new Rent(){id=1, begin=new DateTime(2021, 04, 23),end=new DateTime(2021,05,01),CustomerId=1, CarId=2, customer=c1 ,car=car1},
                new Rent(){id=2, begin=new DateTime(2021, 04, 23),end=new DateTime(2021,04,29),CustomerId=1, CarId=2, customer=c1,car=car1},

            }.AsQueryable());
            logic = new RentLogic(mockRentRepo.Object);
        }

        [Test]
        public void RentTimeByCustomerTest()
        {
            var test = logic.RentTimeByCustomer();
            Assert.That(test.First().GetType().GetProperty("RentedDays").GetValue(test.First(), null), Is.EqualTo(14.0));
        }
        [Test]
        public void HowManyBrandRentedByPersonsTest()
        {
            var test = logic.HowManyBrandRentedByPersons("E26");
            Assert.That(test.First().GetType().GetProperty("Count").GetValue(test.First(), null), Is.EqualTo(2));
        }

        [Test]
        public void RentsByDayTest()
        {

            var test = logic.RentsByDay();
            Assert.That(test.First().GetType().GetProperty("RentsToday").GetValue(test.First(), null), Is.EqualTo(2));
        }

        [Test]
        public void HowManyTimesRentedACarTest()
        {

            var test = logic.HowManyTimesRentedACar();
            Assert.That(test.First().GetType().GetProperty("Count").GetValue(test.First(), null), Is.EqualTo(2));
        }




    }
}
