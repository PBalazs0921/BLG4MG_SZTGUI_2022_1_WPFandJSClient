using BLG4MG_HFT_2021222.Models;
using ConsoleTools;
using System;

namespace BLG4MG_HFT_2021222.Client
{
    class Program
    {
        static RestService rest;
        static void Create(string entity)
        {


            switch (entity)
            {
                case "Brand": 
                    
                    break;

                case "Car":
                 
                    break;

                case "Customer":

                    break;

                case "Rent":

                    break;
            }
        }

        static void List(string entity)
        {
            switch (entity)
            {
                case "Brand":
                    var brands = rest.Get<Brand>("Brand");
                    foreach (var item in brands)
                    {
                        Console.WriteLine(item.BrandName);
                    }
                    Console.ReadKey();
                    break;

                case "Car":
                    var Cars = rest.Get<Car>("Car");
                    foreach (var item in Cars)
                    {
                        Console.WriteLine(item.Model);
                    }
                    Console.ReadKey();
                    break;

                case "Customer":
                    var customers = rest.Get<Customer>("Customer");
                    foreach (var item in customers)
                    {
                        Console.WriteLine(item.Name);
                    }
                    Console.ReadKey();
                    break;

                case "Rent":
                    var rents = rest.Get<Rent>("Rent");
                    foreach (var item in rents)
                    {
                        Console.WriteLine("Berlo neve:" + item.customer.Name);
                        Console.WriteLine("Berles Kezdete:" + item.begin);
                        Console.WriteLine("Berles vege:" + item.end);
                        Console.WriteLine("Berelt auto:" + item.car.Model);
                    }
                    Console.ReadKey();


                    break;
            }

        }

        static void Delete(string entity)
        {
            

            Console.WriteLine("Enter a(n) " + entity + " id to delete:");
            int deleteid = int.Parse(Console.ReadLine());


            switch (entity)
            {
                case "Brand":
                    rest.Delete(deleteid,entity.ToLower());
                    break;

                case "Car":
                    rest.Delete(deleteid, entity.ToLower());

                    break;

                case "Customer":
                    rest.Delete(deleteid, entity.ToLower());

                    break;

                case "Rent":
                    rest.Delete(deleteid, entity.ToLower());
                    break;
            }

        }
        
        static void Update(string entity)
        {
            int id;
            switch (entity)
            {
                case "Brand":
                    Console.Write("Enter brand's id to update: ");
                    id = int.Parse(Console.ReadLine());
                    Brand b = rest.Get<Brand>(id, "brand");
                    Console.Write($"Enter the new name for "+b.BrandName);
                    string name = Console.ReadLine();
                    b.BrandName = name;
                    rest.Put(b, "brand");
                    break;

                case "Car":
                    Console.Write("Enter Car's id to update: ");
                    id = int.Parse(Console.ReadLine());
                    Car ca = rest.Get<Car>(id, "car");
                    Console.Write($"Enter the new name for " + ca.Model);
                    string nameca = Console.ReadLine();
                    ca.Model = nameca;
                    rest.Put(ca, "brand");
                    break;


                case "Customer":
                    Console.Write("Enter Customer's id to update: ");
                    id = int.Parse(Console.ReadLine());
                    Customer c = rest.Get<Customer>(id, "customer");
                    Console.Write($"New name [old: {c.Name}]: ");
                    string namec = Console.ReadLine();
                    c.Name = namec;
                    rest.Put(c, "renter");
                    break;

                case "Rent":
                    Console.WriteLine("Enter the ID of the rent that you want to edit: ");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine("What part of this rent entry do you want to edit?");
                    break;
            }
        }


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:61417/", "brand");

            var CarSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Exit", ConsoleMenu.Close);

            var CustomerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("customer"))
                .Add("Create", () => Create("customer"))
                .Add("Delete", () => Delete("customer"))
                .Add("Update", () => Update("customer"))
                .Add("Exit", ConsoleMenu.Close);

            var BrandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Brand"))
                .Add("Create", () => Create("Brand"))
                .Add("Delete", () => Delete("Brand"))
                .Add("Update", () => Update("Brand"))
                .Add("Exit", ConsoleMenu.Close);

            var RentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Rent"))
                .Add("Create", () => Create("Rent"))
                .Add("Delete", () => Delete("Rent"))
                .Add("Update", () => Update("Rent"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Brands", () => BrandSubMenu.Show())
                .Add("Rents", () => RentSubMenu.Show())
                .Add("Customers", () => CustomerSubMenu.Show())
                .Add("Cars", () => CarSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
