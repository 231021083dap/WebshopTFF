﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebshopAPI.DB;

namespace WebshopAPI.Migrations
{
    [DbContext(typeof(WebshopContext))]
    [Migration("20210921074538_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebshopAPI.DB.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Hardware"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Gaming"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "PC & Tablets"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "TV & HIFI"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Mobile"
                        });
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemAmount")
                        .HasColumnType("int");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemDiscount")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemPrice")
                        .HasColumnType("int");

                    b.Property<string>("ItemStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            ItemAmount = 10,
                            ItemDescription = "Shitty bærbar, minimal teamkilling ability with this one.",
                            ItemDiscount = 5,
                            ItemName = "Acer 15.6 tommer laptop",
                            ItemPrice = 4999,
                            ItemStatus = "In Stock",
                            SubCategoryId = 1
                        },
                        new
                        {
                            ItemId = 2,
                            ItemAmount = 2,
                            ItemDescription = "Top teir audio to own your teammates",
                            ItemDiscount = 0,
                            ItemName = "SteelSeries Arctic 7 Wireless",
                            ItemPrice = 999,
                            ItemStatus = "In Stock",
                            SubCategoryId = 2
                        });
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.OrderItems", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CurrentPrice")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            Amount = 5,
                            CurrentPrice = 500,
                            ItemId = 1,
                            OrderId = 1
                        },
                        new
                        {
                            OrderItemId = 2,
                            Amount = 2,
                            CurrentPrice = 1000,
                            ItemId = 2,
                            OrderId = 2
                        });
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            OrderStatus = "In Shipping",
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            OrderStatus = "In Cart",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Customer"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Employee"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 4,
                            RoleName = "SuperUser"
                        });
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.SubCategory", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory");

                    b.HasData(
                        new
                        {
                            SubId = 1,
                            CategoryId = 1,
                            SubName = "Laptop"
                        },
                        new
                        {
                            SubId = 2,
                            CategoryId = 1,
                            SubName = "PC Audio"
                        },
                        new
                        {
                            SubId = 3,
                            CategoryId = 1,
                            SubName = "Monitors"
                        },
                        new
                        {
                            SubId = 4,
                            CategoryId = 5,
                            SubName = "MobilTelefoner"
                        },
                        new
                        {
                            SubId = 5,
                            CategoryId = 5,
                            SubName = "SmartWatches"
                        });
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Address = "Noobstreet",
                            Email = "Test@gmail.com",
                            FirstName = "Anders",
                            LastName = "Noob",
                            MiddleName = "Er",
                            Password = "TestTest",
                            Phone = "20202020",
                            PostalCode = "1337",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.Item", b =>
                {
                    b.HasOne("WebshopAPI.DB.Entities.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.OrderItems", b =>
                {
                    b.HasOne("WebshopAPI.DB.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.Orders", b =>
                {
                    b.HasOne("WebshopAPI.DB.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.SubCategory", b =>
                {
                    b.HasOne("WebshopAPI.DB.Entities.Category", "Category")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.User", b =>
                {
                    b.HasOne("WebshopAPI.DB.Entities.Role", "UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("WebshopAPI.DB.Entities.Category", b =>
                {
                    b.Navigation("SubCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
