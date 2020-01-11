using System;

using GraphQL;

using Playground.Database;

namespace Playground.Graphql
{
    /// <summary>
    /// GraphQL resolver used for mutations
    /// 
    /// The Mutation class acts as the public API for changing data.
    /// </summary>
    [GraphQLMetadata("Mutation")]
    public class Mutation
    {
        /// <summary>
        /// GraphQL resolver used to add a new Customer
        /// </summary>
        /// <param name="name">The name of the Customer to add</param>
        /// <returns>The newly created Customer</returns>
        [GraphQLMetadata("addCustomer")]
        public Customer Add(string name)
        {
            return null;
        }
    }
}
