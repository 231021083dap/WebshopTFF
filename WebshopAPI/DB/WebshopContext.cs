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
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; } 
        




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemId = 1,
                    ItemName = "Acer 15.6 tommer laptop",
                    ItemDescription = "Shitty bærbar, minimal teamkilling ability with this one.",
                    SubCategoryId = 1,
                    ItemPrice = 4999,
                    ItemDiscount = 5,
                    ItemAmount = 10
                },
                new Item
                {
                    ItemId = 2,
                    ItemName = "SteelSeries Arctic 7 Wireless",
                    ItemDescription = "Top teir audio to own your teammates",
                    SubCategoryId = 2,
                    ItemPrice = 999,
                    ItemDiscount = 0,
                    ItemAmount = 2
                    
                });


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Role = Helpers.Role.Employee,
                    Email = "Test@gmail.com",
                    Phone = "20202020",
                    Password = "TestTest",
                    FirstName = "Anders",
                    MiddleName = "Er",
                    LastName = "Noob",
                    Address = "Noobstreet",
                    PostalCode = "1337"
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
                    CategoryName = "Mobile"
                });


            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory
                {
                    SubId = 1,
                    SubName = "Laptop",
                    CategoryId = 1
                },
                new SubCategory
                {
                    SubId = 2,
                    SubName = "PC Audio",
                    CategoryId = 1
                },
                new SubCategory
                {
                    SubId = 3,
                    SubName = "Monitors",
                    CategoryId = 1
                }, 
                new SubCategory
                {
                    SubId = 4,
                    SubName = "MobilTelefoner",
                    CategoryId = 5
                },
                new SubCategory
                {
                    SubId = 5,
                    SubName = "SmartWatches",
                    CategoryId = 5
                });            

            modelBuilder.Entity<Orders>().HasData(
                new Orders
                {
                    OrderId = 1,
                    UserId = 1,
                    OrderStatus = "In Shipping"
                },
                new Orders
                {
                    OrderId = 2,
                    UserId = 1,
                    OrderStatus = "In Cart"
                });

            modelBuilder.Entity<OrderItems>().HasData(
                new OrderItems
                {
                    OrderItemId = 1,
                    OrderId = 1,
                    ItemId = 1,
                    Amount = 5,
                    CurrentPrice = 500

                },
                 new OrderItems
                 {
                     OrderItemId = 2,
                     OrderId = 2,
                     ItemId = 2,
                     Amount = 2,
                     CurrentPrice = 1000
                 });

        }
    }
}
