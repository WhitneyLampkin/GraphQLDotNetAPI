using System;

using GraphQL;
using GraphQL.Types;

using Playground.Database;

namespace Playground.Graphql
{
    /// <summary>
    /// GraphQL schema
    /// </summary>
    public class MySchema 
    {
        /// <summary>
        /// TODO: Fill in later
        /// </summary>
        private ISchema _schema { get; set; }

        /// <summary>
        /// TODO: Fill in later
        /// </summary>
        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }

        /// <summary>
        /// TODO: Fill in later
        /// </summary>
        public MySchema()
        {
            this._schema = Schema.For(@"
                type Customer {
                    customerID: ID
                    name: String
                    orders: [Order]
                }

                type Order {
                    orderID: ID
                    customerID: ID
                    employeeID: ID
                    orderDate: Date
                    Customer: Customer
                }

                type Mutation {
                    addCustomer(name: String): Customer
                }

                type Query {    
                    customers: [Customer]
                    customer(customerID: ID): Customer
                    hello: String
                    orders: [Orders]
                    order(orderID: ID): Order
                }
            ", _ =>
            {
                _.Types.Include<Query>();
                _.Types.Include<Mutation>();
            });
        }
    }
}
