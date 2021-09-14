using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebshopAPI.DB.Entities;

namespace WebshopAPI.DB
{
    public class WebshopContext : DbContext
    {
        public WebshopContext() { }

        public WebshopContext(DbContextOptions<WebshopContext> options) : base(options) { }

        public DbSet<Item> Item { get; set; }
        public DbSet <User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemId = 1,
                    ItemName = "Acer 15.6 tommer laptop",
                   // ItemCategory = "PC",
                    ItemSubCategory = "Bærbar",
                    ItemPrice = 4999,
                    ItemOnSale = false
                },
                new Item
                {
                    ItemId = 2,
                    ItemName = "SteelSeries Arctic 7 Wireless",
                   //ItemCategory = "PC",
                    ItemSubCategory = "PC Audio",
                    ItemPrice = 999,
                    ItemOnSale = true
                });
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    UserRoleId = 1,
                    Email = "Test@gmail.com",
                    Phone = 20202020,
                    Password = "TestTest",
                    FirstName = "Anders",
                    LastName = "Noob",
                    MiddleName = "Er",
                    Address = "Noobstreet",
                    PostalCode = 1337
                });
        }
    }
}
