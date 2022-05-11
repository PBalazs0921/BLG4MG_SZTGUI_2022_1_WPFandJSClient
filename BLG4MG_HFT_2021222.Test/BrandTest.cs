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
    public class BrandTest
    {
        BrandLogic logic;
        Mock<IRepository<Brand>> mockBrandRepo;
        [SetUp]
        public void Init()
        {
            mockBrandRepo = new Mock<IRepository<Brand>>();
            mockBrandRepo.Setup(x => x.ReadAll()).Returns(new List<Brand>()
            {
                new Brand(){ BrandId = 1, BrandName = "Audi"},
                new Brand(){ BrandId = 2, BrandName = "Ferrari"},
                new Brand(){ BrandId = 3, BrandName = "Lada"}
            }.AsQueryable());
            logic = new BrandLogic(mockBrandRepo.Object);
        }
        [Test]
        public void CreateBrandTest()
        {
            var brand = new Brand() { BrandId = 4, BrandName = "Skoda" };
            logic.Create(brand);
            mockBrandRepo.Verify(r => r.Create(brand), Times.Once());
        }
        [Test]
        public void UpdateBrandTest()
        {
            var id = new Brand() { BrandId = 1, BrandName = "BMW" };
            logic.Update(id);
            mockBrandRepo.Verify(r => r.Update(id), Times.Once());
        }



    }
}
