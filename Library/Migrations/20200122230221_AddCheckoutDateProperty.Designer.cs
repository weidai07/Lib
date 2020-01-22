﻿// <auto-generated />
using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20200122230221_AddCheckoutDateProperty")]
    partial class AddCheckoutDateProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorName");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<int?>("InventoryId");

                    b.Property<int>("TitleId");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("TitleId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.Checkout", b =>
                {
                    b.Property<int>("CheckoutId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<int>("InventoryId");

                    b.Property<int>("PatronId");

                    b.HasKey("CheckoutId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("PatronId");

                    b.ToTable("CheckoutTable");
                });

            modelBuilder.Entity("Library.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Available");

                    b.Property<int>("CopiesAvailable");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Library.Models.Patron", b =>
                {
                    b.Property<int>("PatronId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PatronName");

                    b.HasKey("PatronId");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("Library.Models.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TitleName");

                    b.HasKey("TitleId");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Author", "Author")
                        .WithMany("Titles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.Inventory")
                        .WithMany("Books")
                        .HasForeignKey("InventoryId");

                    b.HasOne("Library.Models.Title", "Title")
                        .WithMany("Authors")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Models.Checkout", b =>
                {
                    b.HasOne("Library.Models.Inventory", "Inventory")
                        .WithMany("Patrons")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.Patron", "Patron")
                        .WithMany("Inventories")
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
