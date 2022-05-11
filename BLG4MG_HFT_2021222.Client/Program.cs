using ConsoleTools;
using System;

namespace BLG4MG_HFT_2021222.Client
{
    class Program
    {
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

                    break;

                case "Car":

                    break;

                case "Customer":

                    break;

                case "Rent":

                    break;
            }

        }

        static void Delete(string entity)
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
        
        static void Update(string entity)
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


        static void Main(string[] args)
        {


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
