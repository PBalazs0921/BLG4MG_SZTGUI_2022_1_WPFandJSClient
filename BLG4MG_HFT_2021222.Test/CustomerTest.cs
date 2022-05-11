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
    [TestFixture]
    class CustomerTest
    {
        CustomerLogic logic;
        Mock<IRepository<Customer>> mockCustomerRepo;
        [SetUp]
        public void Init()
        {
            mockCustomerRepo = new Mock<IRepository<Customer>>();
            mockCustomerRepo.Setup(x => x.ReadAll()).Returns(new List<Customer>()
            {
                new Customer(){id=1,Name="teszt 1"}
            }.AsQueryable());
            logic = new CustomerLogic(mockCustomerRepo.Object);
        }

        [Test]
        public void CreateRenterTest()
        {
            //ACT
            var customer = new Customer() { id = 3, Name = "Teszt 2 " };
            logic.Create(customer);

            //ASSERT
            mockCustomerRepo.Verify(r => r.Create(customer), Times.Once());
        }
    }
}
