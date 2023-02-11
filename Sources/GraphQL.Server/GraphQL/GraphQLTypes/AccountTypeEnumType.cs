namespace DemoGraphQL.Server.GraphQL.GraphQLTypes
{
    using DemoGraphQL.Server.Entities;
    using global::GraphQL.Types;

    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object.";
        }
    }
}