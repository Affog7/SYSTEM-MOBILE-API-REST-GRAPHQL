namespace DemoGraphQL.Server.Repository
{
    using DemoGraphQL.Server.Contracts;
    using DemoGraphQL.Server.Entities;
    using DemoGraphQL.Server.Entities.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId) => _context.Accounts
                    .Where(a => a.OwnerId.Equals(ownerId))
            .ToList();
    }
}