using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Playground.Database;

namespace Playground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            using(var db = new StoreContext())
            {
                var customerDbEntry = db.Customers.Add(
                    new Customer
                    {
                        CustomerID = 1,
                        Name = "Whitney Lampkin"
                    }
                );

                db.SaveChanges();

                db.Orders.AddRange(
                    new Order
                    {
                        OrderID = 1,
                        Customer = new Customer
                        {
                            CustomerID = customerDbEntry.Entity.CustomerID
                        },
                        EmployeeID = 1,
                        OrderDate = DateTime.Now
                    },
                    new Order
                    {
                        OrderID = 2, 
                        Customer = new Customer
                        {
                            CustomerID = customerDbEntry.Entity.CustomerID
                        },
                        EmployeeID = 2, 
                        OrderDate = DateTime.Now 
                    }
                );

                db.SaveChanges();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
