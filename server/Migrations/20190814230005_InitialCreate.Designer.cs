﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Models.Database;

namespace server.Migrations
{
    [DbContext(typeof(MySqlDbContext))]
    [Migration("20190814230005_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("server.Models.Domain.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateLastUpdated");

                    b.Property<int>("Deleted");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.HasKey("InventoryID");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("server.Models.Domain.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<int>("Deleted");

                    b.Property<string>("Dimensions");

                    b.Property<int>("NotificationQuantity");

                    b.Property<double>("Price");

                    b.Property<string>("ProductName");

                    b.Property<int>("SKU");

                    b.Property<string>("Size");

                    b.Property<string>("TrimColor");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
