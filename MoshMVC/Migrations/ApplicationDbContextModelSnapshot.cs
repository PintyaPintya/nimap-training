﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoshMVC.Data;

#nullable disable

namespace MoshMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoshMVC.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<byte>("MembershipTypeId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("isSubscribedToNewsLetter")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateOnly(2025, 1, 12),
                            MembershipTypeId = (byte)1,
                            Name = "Qwer Tyui",
                            isSubscribedToNewsLetter = false
                        },
                        new
                        {
                            Id = 2,
                            MembershipTypeId = (byte)2,
                            Name = "Asdf  Ghjk",
                            isSubscribedToNewsLetter = true
                        });
                });

            modelBuilder.Entity("MoshMVC.Models.MembershipType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<byte>("DiscountRate")
                        .HasColumnType("tinyint");

                    b.Property<byte>("DurationInMonths")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("SignUpFee")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            DiscountRate = (byte)0,
                            DurationInMonths = (byte)0,
                            Name = "Pay as you go",
                            SignUpFee = (short)0
                        },
                        new
                        {
                            Id = (byte)2,
                            DiscountRate = (byte)10,
                            DurationInMonths = (byte)1,
                            Name = "Monthly",
                            SignUpFee = (short)30
                        },
                        new
                        {
                            Id = (byte)3,
                            DiscountRate = (byte)15,
                            DurationInMonths = (byte)3,
                            Name = "Quarterly",
                            SignUpFee = (short)90
                        },
                        new
                        {
                            Id = (byte)4,
                            DiscountRate = (byte)20,
                            DurationInMonths = (byte)12,
                            Name = "Yearly",
                            SignUpFee = (short)300
                        });
                });

            modelBuilder.Entity("MoshMVC.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateAdded")
                        .HasColumnType("date");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAdded = new DateOnly(2025, 1, 13),
                            Genre = "Drama",
                            Name = "The Shawshank Redemption",
                            ReleaseDate = new DateOnly(1994, 9, 22),
                            Stock = 3
                        },
                        new
                        {
                            Id = 2,
                            DateAdded = new DateOnly(2025, 1, 13),
                            Genre = "Crime",
                            Name = "The Godfather",
                            ReleaseDate = new DateOnly(1972, 3, 24),
                            Stock = 5
                        },
                        new
                        {
                            Id = 3,
                            DateAdded = new DateOnly(2025, 1, 13),
                            Genre = "Action",
                            Name = "The Dark Knight",
                            ReleaseDate = new DateOnly(2008, 7, 18),
                            Stock = 5
                        },
                        new
                        {
                            Id = 4,
                            DateAdded = new DateOnly(2025, 1, 13),
                            Genre = "Drama",
                            Name = "Forrest Gump",
                            ReleaseDate = new DateOnly(1994, 7, 6),
                            Stock = 5
                        },
                        new
                        {
                            Id = 5,
                            DateAdded = new DateOnly(2025, 1, 13),
                            Genre = "Sci-Fi",
                            Name = "Inception",
                            ReleaseDate = new DateOnly(2010, 7, 16),
                            Stock = 5
                        });
                });

            modelBuilder.Entity("MoshMVC.Models.Customer", b =>
                {
                    b.HasOne("MoshMVC.Models.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });
#pragma warning restore 612, 618
        }
    }
}
