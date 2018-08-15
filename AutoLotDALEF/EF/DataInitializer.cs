using AutoLotDALEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDALEF.EF
{
   public class DataInitializer: DropCreateDatabaseAlways<AutoLotEntities>
    {
        protected override void Seed(AutoLotEntities context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{FirstName = "Dave", LastName = "Brenner" },
                new Customer{FirstName = "Matt", LastName = "Walton" },
                new Customer{FirstName = "Steve", LastName = "Hagen" },
                new Customer{FirstName = "Pat", LastName = "Walton" },
                new Customer{FirstName = "Bad", LastName = "Customer" },
            };
            customers.ForEach(x => context.Customers.Add(x));

            List<Inventory> cars = new List<Inventory>
            {
                new Inventory{Make = "VW", Color = "Black", PetName = "Zippy"},
                new Inventory{Make = "Ford", Color = "Rust", PetName = "Rusty"},
                new Inventory{Make = "Saab", Color = "Black", PetName = "Mel"},
                new Inventory{Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
                new Inventory{Make = "BMW", Color = "Black", PetName = "Bimmer"},
                new Inventory{Make = "BMW", Color = "Green", PetName = "Hank"},
                new Inventory{Make = "BMW", Color = "Pink", PetName = "Pinky"},
                new Inventory{Make = "Pinto", Color = "Black", PetName = "Pete"},
                new Inventory{Make = "Yugo", Color = "Brown", PetName = "Brownie"},
            };
            cars.ForEach(x => context.Inventory.Add(x));

            List<Order> orders = new List<Order>
            {
                new Order{Car = cars[0], Customer = customers[0]},
                new Order{Car = cars[1], Customer = customers[1]},
                new Order{Car = cars[2], Customer = customers[2]},
                new Order{Car = cars[3], Customer = customers[3]},
            };
            orders.ForEach(x => context.Orders.Add(x));

            context.CreditRisks.Add(new CreditRisk
            {
                CustId = customers[4].CustId,
                FirstName = customers[4].FirstName,
                LastName = customers[4].LastName,
            });
            context.SaveChanges();
        }
    }
}
