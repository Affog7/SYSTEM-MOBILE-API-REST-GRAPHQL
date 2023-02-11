namespace DemoGraphQL.Server.Repository
{
    using DemoGraphQL.Server.Contracts;
    using DemoGraphQL.Server.Entities;
    using DemoGraphQL.Server.Entities.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public void DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }

        public IEnumerable<Owner> GetAll() => _context.Owners.ToList();

        public IEnumerable<Products> GetAllProducts()
        {
            var list = new List<Products>()
                {
                    new Products{ Id = 1,Name = "gfhjk", Price = 12, Quantity = 21},
                      new Products{ Id = 4,Name = "erjhfzb", Price = 12, Quantity = 21},
                        new Products{ Id = 11,Name = "rejfh", Price = 12, Quantity = 99},
                          new Products{ Id = 10,Name = "jhb", Price = 12, Quantity = 21},
                            new Products{ Id = 3,Name = "FDGFHGH", Price = 12, Quantity = 20},
                              new Products{ Id = 2,Name = "2657F", Price = 12, Quantity = 21},
                };

            return list;
        }

        public Owner GetById(Guid id) => _context.Owners.SingleOrDefault(o => o.Id.Equals(id));

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;

            _context.SaveChanges();

            return dbOwner;
        }
    }
}