namespace DemoGraphQL.Server.Contracts
{
    using DemoGraphQL.Server.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IAccountRepository
    {
        Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds);

        IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId);
    }
}