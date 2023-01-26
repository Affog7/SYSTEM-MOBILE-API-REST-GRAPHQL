using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EF;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    
    public DbSet<Product> Product { get; set; }
    public DbSet<Stock> Stock { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        Stock stock = new Stock {  Id = 1, Name ="Stock1"};

        modelBuilder.Entity<Stock>().HasData(stock);
 
        modelBuilder.Entity<Product>().HasData(new Product { Id = 1, StockForeignKey = 1,  Name = "So What" , Price = 122, Quantity=12},
            new Product { Id = 2, StockForeignKey = 1, Name = "PC ", Price = 12, Quantity = 12 },
            new Product { Id = 3, StockForeignKey = 1, Name = "Gamer", Price = 22, Quantity = 2 },
            new Product { Id = 4, StockForeignKey = 1, Name = "Linge", Price = 12, Quantity = 12 },
            new Product { Id = 5, StockForeignKey = 1, Name = "MacBook", Price = 122, Quantity = 1 },
            new Product { Id = 6, StockForeignKey = 1, Name = "Souris", Price = 42, Quantity = 32 }
            );
    }
}

