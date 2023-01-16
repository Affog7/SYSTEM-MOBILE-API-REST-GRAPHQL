using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EF;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    public DbSet<Product> Product { get; set; }


  
}

