namespace DemoGraphQL.Server.GraphQL.GraphQLTypes
{
    using DemoGraphQL.Server.Contracts;
    using DemoGraphQL.Server.Entities;
    using global::GraphQL.DataLoader;
    using global::GraphQL.Types;
    using System;

    public class OwnerType : ObjectGraphType<Owner>
    {
     }
}