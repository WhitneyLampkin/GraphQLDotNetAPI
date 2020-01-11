using System;
using System.Collections.Generic;
using System.Linq;

using GraphQL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Playground.Database;

namespace Playground.Graphql
{
    /// <summary>
    /// Class that handles every possible request to query in the schema
    /// 
    /// There is a method that corresponds to everything can be queried for.
    /// 
    /// The decorator GraphQLMetadata helps to map from the schema to the methods 
    /// and is called a resolver.
    /// 
    /// The Query class acts as the public API for retrieving data.
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Handles the GraphQL customers request
        /// </summary>
        /// <returns>A collection of Customers</returns>
        [GraphQLMetadata("customers")]
        public IEnumerable<Customer> GetCustomers()
        {
            using (var db = new StoreContext())
            {
                return db.Customers
                    .Include(c => c.Orders)
                    .ToList();
            }
        }

        /// <summary>
        /// Handles the GraphQL orders request
        /// </summary>
        /// <returns>A collection of Orders</returns>
        [GraphQLMetadata("orders")]
        public IEnumerable<Order> GetOrders()
        {
            using (var db = new StoreContext())
            {
                return db.Orders
                    .Include(o => o.Customer)
                    .ToList();
            }
        }

        /// <summary>
        /// Handles the GraphQL customer request
        /// </summary>
        /// <param name="customerID">Unique identifier of the customer to retrieve</param>
        /// <returns></returns>
        [GraphQLMetadata("customer")]
        public Customer GetCustomer(int customerID)
        {
            return new Customer { CustomerID = 1, Name = "Whitney Lampkin" };

            //using (var db = new StoreContext())
            //{
            //    return db.Customers
            //        .Include(c => c.Orders)
            //        .SingleOrDefault(c => c.CustomerID == customerID);
            //}
        }

        /// <summary>
        /// Handles the GraphQL "hello" request
        /// </summary>
        /// <returns>"Hello" text</returns>
        [GraphQLMetadata("hello")]
        public string GetHello()
        {
            return "Hello";
        }
    }
}
