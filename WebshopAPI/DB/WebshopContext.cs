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
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }


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
                    ItemDiscount = 5,
                    ItemAmount = 0
                },
                new Item
                {
                    ItemId = 2,
                    ItemName = "SteelSeries Arctic 7 Wireless",
                   //ItemCategory = "PC",
                    ItemSubCategory = "PC Audio",
                    ItemPrice = 999,
                    ItemDiscount = 0,
                    ItemAmount = 2
                    
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


            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Hardware"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Gaming"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "PC & Tablets"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "TV & HIFI"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Mobil"
                });

            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory
                {
                    SubId = 1,
                    SubName = "MobilTelefoner",
                    CategoryId = 5
                },
                new SubCategory
                {
                    SubId = 2,
                    SubName = "SmartWatches",
                    CategoryId = 5
                });
        }
    }
}
