using BLG4MG_HFT_2021222.Models;
using ConsoleTools;
using System;
using System.Linq;

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
                    Console.WriteLine("Enter brand name: ");
                    string name = Console.ReadLine();
                    rest.Post(new Brand() { BrandName = name }, "brand");
                    break;

                case "Car":
                    Console.WriteLine("Enter car name: ");
                    string namecar = Console.ReadLine();

                    Console.Write("Enter car cost: ");
                    int cost = int.Parse(Console.ReadLine());

                    Console.Write("Enter car brand: ");
                    string brand = Console.ReadLine().ToLower();
                    Brand b = rest.Get<Brand>("brand").Where(x => x.BrandName.ToLower() == brand).FirstOrDefault();

                    Car car = new Car() { Model = namecar, Cost = cost, BrandId = b.BrandId };
                    rest.Post(car, "car");
                    break;

                case "Customer":
                    Console.Write("Enter Customer name: ");
                    string namec = Console.ReadLine();
                    var renter = new Customer() { Name = namec };
                    rest.Post(renter, "customer");
                    break;

                case "Rent":
                    Console.Write("Enter customer's name: ");
                    string namer = Console.ReadLine();
                    var renterid = rest.Get<Customer>("renter").Where(x => x.Name == namer).Select(x => x.id).FirstOrDefault();

                    Console.Write("Enter car name: ");
                    string model = Console.ReadLine();
                    var modelid = rest.Get<Car>("car").Where(x => x.Model == model).Select(x => x.id).FirstOrDefault();

                    Rent renting = new Rent() { CarId = modelid, CustomerId = renterid, begin = DateTime.Today };
                    rest.Post(renting, "rental");

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
                        Console.WriteLine("Customer name:" + item.customer.Name);
                        Console.WriteLine("Start of rent:" + item.begin);
                        Console.WriteLine("End of Rent" + item.end);
                        Console.WriteLine("Rented car: "+rest.Get<Car>(item.CarId, "car").Model);
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
                    rest.Put(ca, "car");
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
                    Rent RentChange = rest.Get<Rent>(id, "rental");
                    Console.WriteLine("What part of this rent entry do you want to edit? Write the corresponding number: 1, Renter 2,Car 3,Start date 4,End date");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Customer renter = rest.Get<Customer>(RentChange.id, "customer");
                            Console.Write($"Who do you want the new customer on this rent to be?");
                            string nameofc = Console.ReadLine();
                            int renterid = rest.Get<Customer>("customer").Where(x => x.Name == nameofc).Select(x => x.id).FirstOrDefault();
                            RentChange.id = renterid;
                            break;
                        case 2:
                            Car rentcar = rest.Get<Car>(RentChange.id, "car");
                            Console.Write($"What do you want the new car to be?");
                            string carname = Console.ReadLine();
                            int carid = rest.Get<Car>("car").Where(x => x.Model == carname).Select(x => x.id).FirstOrDefault();
                            RentChange.id = carid;
                            break;

                        case 3:
                            Console.Write($"New rent start date [old: {RentChange.begin}](format: 2022*05*01): ");
                            string[] date = Console.ReadLine().Split('*');
                            DateTime dt = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]));
                            RentChange.begin = dt;
                            break;
                        case 4:
                            Console.Write($"New rent end date [old: {RentChange.begin}](format: 2022*05*01): ");
                            string[] date2 = Console.ReadLine().Split('*');
                            DateTime dt2 = new DateTime(int.Parse(date2[0]), int.Parse(date2[1]), int.Parse(date2[2]));
                            RentChange.begin = dt2;
                            break;
                        default:
                            break;
                    }
                    rest.Put(RentChange, "rental");
                    Console.ReadKey();
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
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
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
