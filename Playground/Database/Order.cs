using System;

namespace Playground.Database
{
    /// <summary>
    /// GraphQL type for an order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Unique identifier belonging to the order
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Uniquer identifier for the employee associated with the order
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// Date and time the order was placed
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Customer who placed the order
        /// </summary>
        public Customer Customer { get; set; }
    }
}
