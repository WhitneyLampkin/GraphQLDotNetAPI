using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GraphQL;
using Microsoft.AspNetCore.Mvc;

using Playground.Graphql;

namespace Playground.Controllers
{
    /// <summary>
    /// Controller used to respond to GraphQL requests
    /// </summary>
    [Route("graphql")]
    [ApiController]
    public class GraphqlController : ControllerBase
    {
        // Note: All GraphQL requests use the verb POST

        /// <summary>
        /// TODO: Fill in later
        /// </summary>
        /// <param name="query">Contains the values submitted with the request that will be converted to GraphQL types</param>
        /// <returns>The values requested in the query if successfully mapped</returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            MySchema schema = new MySchema();
            var inputs = query.Variables.ToInputs();

            var executionOptions = new ExecutionOptions
            {
                Schema = schema.GraphQLSchema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await new DocumentExecuter().ExecuteAsync(executionOptions).ConfigureAwait(false);

            //var result = await new DocumentExecuter().ExecuteAsync(_ =>
            //{
            //    _.Schema = schema.GraphQLSchema;
            //    _.Query = query.Query;
            //    _.OperationName = query.OperationName;
            //    _.Inputs = inputs;
            //});


            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
