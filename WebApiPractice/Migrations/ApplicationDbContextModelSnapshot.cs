﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiPractice.Data;

#nullable disable

namespace WebApiPractice.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("WebApiPractice.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Roles")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@Example.com",
                            Password = "password",
                            Roles = "[\"Admin\",\"User\"]",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user@Example.com",
                            Password = "password",
                            Roles = "[\"User\"]",
                            Username = "user"
                        },
                        new
                        {
                            Id = 3,
                            Email = "test@Example.com",
                            Password = "password",
                            Roles = "[\"Admin\"]",
                            Username = "test"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
