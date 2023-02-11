namespace DemoGraphQL.Server.GraphQL.GraphQLTypes
{
    using global::GraphQL.Types;

    public class OwnerInputType : InputObjectGraphType
    {
        public OwnerInputType()
        {
            Name = "ownerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("address");
        }
    }
}