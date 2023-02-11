using System;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using ISchema = HotChocolate.ISchema;

namespace APIQL.Controllers;
[Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQLController(
            ISchema schema,
            IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

         
    }





