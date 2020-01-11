using System;
using System.Collections.Generic;

namespace Playground.Database
{
    /// <summary>
    /// GraphQL type for a customer
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Unique identifier belonging to the customer
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Customer's first and last name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of orders placed by the customer
        /// </summary>
        public List<Order> Orders { get; set; }
    }
}
