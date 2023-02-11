namespace DemoGraphQL.Server.Contracts
{
    using DemoGraphQL.Server.Entities;
    using DemoGraphQL.Server.Entities.Context;
    using System;
    using System.Collections.Generic;

    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);

        void DeleteOwner(Owner owner);

        IEnumerable<Owner> GetAll();
        IEnumerable<Products> GetAllProducts();
        Owner GetById(Guid id);

        Owner UpdateOwner(Owner dbOwner, Owner owner);
    }
}