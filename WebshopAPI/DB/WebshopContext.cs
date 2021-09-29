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
                    ItemDescription = "Shitty bÃ¦rbar, minimal teamkilling ability with this one.",
                    SubCategoryId = 1,
                    ItemPrice = 4999,
                    ItemDiscount = 5,
                    ItemAmount = 10
                },
                new Item
                {
                    ItemId = 2,
                    ItemName = "SteelSeries Arctic 7 Wireless",
                    ItemDescription = "Top tier audio to own your teammates",
                    SubCategoryId = 2,
                    ItemPrice = 999,
                    ItemDiscount = 0,
                    ItemAmount = 2
                },
                new Item
                {
                    ItemId = 3,
                    ItemName = "Razor Naga Trinity mouse with detachables sides",
                    ItemDescription = "Top tier MMO mouse, and bottom tier for friendly fire",
                    SubCategoryId = 2,
                    ItemPrice = 699,
                    ItemDiscount = 10,
                    ItemAmount = 10
                },
                new Item
                {
                    ItemId = 4,
                    ItemName = "Logitech Office Mouse",
                    ItemDescription = "Great for your wrist, and for your teammates survivabillity ",
                    SubCategoryId = 6,
                    ItemPrice = 150,
                    ItemDiscount = 0,
                    ItemAmount = 250
                },
                new Item
                {
                    ItemId = 5,
                    ItemName = "Logitech G Pro Wireless",
                    ItemDescription = "Top tier mouse in every aspect",
                    SubCategoryId = 2,
                    ItemPrice = 899,
                    ItemDiscount = 15,
                    ItemAmount = 15
                },
                new Item
                {
                    ItemId = 6,
                    ItemName = "Acer Extensa 15 EX215-54 15,5 FHD",
                    ItemDescription = "Some good shit if i may say so myself.",
                    SubCategoryId = 1,
                    ItemPrice = 5999,
                    ItemDiscount = 20,
                    ItemAmount = 15
                },
                new Item
                {
                    ItemId = 7,
                    ItemName = "Garmin Vivoactive 4s GPS smartur, hvid-rose guld",
                    ItemDescription = "Bling bling for your run",
                    SubCategoryId = 5,
                    ItemPrice = 1799,
                    ItemDiscount = 0,
                    ItemAmount = 40
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
                },
                new User
                {
                    UserId = 2,
                    Role = Helpers.Role.Admin,
                    Email = "Alex@gmail.com",
                    Phone = "10101010",
                    Password = "Test1234",
                    FirstName = "Alex",
                    MiddleName = "Er",
                    LastName = "Gud",
                    Address = "NewWorldChamp 1337",
                    PostalCode = "7331"
                },
                new User
                {
                    UserId = 3,
                    Role = Helpers.Role.Customer,
                    Email = "Mathias@gmail.com",
                    Phone = "80088008",
                    Password = "Test4321",
                    FirstName = "Mathias",
                    MiddleName = "Er",
                    LastName = "Noob",
                    Address = "Noobstreet 7331",
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
                    SubId = 6,
                    SubName = "Shitty office equipment",
                    CategoryId = 5
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