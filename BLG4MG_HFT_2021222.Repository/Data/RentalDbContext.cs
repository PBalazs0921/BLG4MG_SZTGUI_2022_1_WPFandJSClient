using BLG4MG_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLG4MG_HFT_2021222.Repository
{
    public class RentalDbContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public RentalDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("cars");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Car>(car=>car
                .HasOne(x => x.Brand)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Customer>()
                .HasMany(t => t.Cars)
                .WithMany(t => t.Customers)
                .UsingEntity<Rent>(
                c => c
                .HasOne(x => x.car)
                .WithMany()
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade),
                c => c
                .HasOne(x => x.customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Rent>(car => car
                .HasOne(x => x.car)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Rent>(car => car
                .HasOne(x => x.customer)
                .WithMany(x => x.Rents)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade));

            Customer[] Customers = new Customer[20];
            for(int i = 0; i < 20; i++)
            {
                Customers[i] = new Customer() { id = i+1, Name = "Customer " + i+1 };
            }
            modelBuilder.Entity<Customer>().HasData(Customers);

            Car[] Cars = new Car[]
            {
                new Car(){ id=1, Model="A4", BrandId=1},
                new Car(){ id=2, Model="SF90 Spider", BrandId=2},
                new Car(){ id=3, Model="E46", BrandId=4},
                new Car(){ id=4, Model="E36", BrandId=4},

            };
            modelBuilder.Entity<Car>().HasData(Cars);

            Brand[] Brands = new Brand[]
            {
                new Brand() { BrandId = 1, BrandName = "Audi" },
                new Brand() { BrandId = 2, BrandName = "Ferrari" },
                new Brand() { BrandId = 3, BrandName = "Ford" },
                new Brand() { BrandId = 4, BrandName = "BMW" },
                new Brand() { BrandId = 5, BrandName = "Lada" },
            };
            modelBuilder.Entity<Brand>().HasData(Brands);

            Rent[] Rents = new Rent[]
            {
                new Rent(){id=1, begin=new DateTime(2021, 04, 23),end=new DateTime(2021,05,01),CustomerId=1, CarId=3},
                new Rent(){id=2, begin=new DateTime(2021, 04, 22),end=new DateTime(2021,04,29),CustomerId=1, CarId=2},
                new Rent(){id=3, begin=new DateTime(2021, 05, 23),end=new DateTime(2021,05,24),CustomerId=1, CarId=4},
                new Rent(){id=4, begin=new DateTime(2021, 01, 01),end=new DateTime(2021,01,02),CustomerId=1, CarId=4, },
            };
            modelBuilder.Entity<Rent>().HasData(Rents);



        }
    }
}
