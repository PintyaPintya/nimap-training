﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiPractice.Data;

#nullable disable

namespace WebApiPractice.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241218054509_fluentapi-async")]
    partial class fluentapiasync
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("WebApiPractice.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Electronics",
                            Description = "Electronic gadgets and devices"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Books",
                            Description = "Various genres of books"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Home Appliances",
                            Description = "Appliances for everyday home use"
                        });
                });

            modelBuilder.Entity("WebApiPractice.Models.DiscountRule", b =>
                {
                    b.Property<int>("DiscountRuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MaximumDiscount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("MinimumPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("DiscountRuleId");

                    b.ToTable("DiscountRules");

                    b.HasData(
                        new
                        {
                            DiscountRuleId = 1,
                            MaximumDiscount = 10m,
                            MinimumPrice = 100m
                        },
                        new
                        {
                            DiscountRuleId = 2,
                            MaximumDiscount = 20m,
                            MinimumPrice = 500m
                        },
                        new
                        {
                            DiscountRuleId = 3,
                            MaximumDiscount = 30m,
                            MinimumPrice = 999m
                        });
                });

            modelBuilder.Entity("WebApiPractice.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2,
                            Description = "Bestselling novel with an intriguing plot",
                            Discount = 0m,
                            Name = "Novel",
                            Price = 50m
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3,
                            Description = "Compact microwave oven suitable for small kitchens",
                            Discount = 10m,
                            Name = "Microwave",
                            Price = 150m
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Description = "Latest model smartphone with advanced features",
                            Discount = 20m,
                            Name = "Smartphone",
                            Price = 800m
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            Description = "High-performance laptop for gaming and productivity",
                            Discount = 30m,
                            Name = "Laptop",
                            Price = 1200m
                        });
                });

            modelBuilder.Entity("WebApiPractice.Models.Product", b =>
                {
                    b.HasOne("WebApiPractice.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebApiPractice.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
