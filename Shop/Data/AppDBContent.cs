using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.Data.Models;

namespace Shop.Data
{
    public class AppDBContent : DbContext
    {
        
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options){}

        public DbSet<Car> Car {get; set;}
        public DbSet<Category> Category { get; set;}
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseSqlite(@"Data Source=Shop\\DataBase\\ShopDb.db");
        //=> optionsBuilder.UseSqlite(@"Data Source=Users\\vovatk\\Doc\\ProjectsDotNet\\Shop\\Shop\\Data\\DataBase\\ShopDb.db");

        /*internal IEnumerable<Category> Category()
        {
            throw new NotImplementedException();
        }
        */
    }
}
