﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderService.Data;

#nullable disable

namespace OrderService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240124065939_FirstInit")]
    partial class FirstInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderService.Data.Domain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OrderService.Data.Domain.MarketingArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AreaCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AreaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MarketingAreas");
                });

            modelBuilder.Entity("OrderService.Data.Domain.ProductSparepart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("COGS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UOM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductSpareparts");
                });

            modelBuilder.Entity("OrderService.Data.Domain.SalesOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("OrderQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("OrderedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ProductSparepartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SalesType")
                        .HasColumnType("int");

                    b.Property<decimal?>("TotalOrderPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductSparepartId");

                    b.ToTable("SalesOrders");
                });

            modelBuilder.Entity("OrderService.Data.Domain.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarketingAreaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MarketingAreaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarketingAreaId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("OrderService.Data.Domain.ProductSparepart", b =>
                {
                    b.HasOne("OrderService.Data.Domain.Store", "Stores")
                        .WithMany("ProductSpareparts")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("OrderService.Data.Domain.SalesOrder", b =>
                {
                    b.HasOne("OrderService.Data.Domain.Customer", "Customer")
                        .WithMany("SalesOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OrderService.Data.Domain.ProductSparepart", "ProductSparepart")
                        .WithMany("SalesOrders")
                        .HasForeignKey("ProductSparepartId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("ProductSparepart");
                });

            modelBuilder.Entity("OrderService.Data.Domain.Store", b =>
                {
                    b.HasOne("OrderService.Data.Domain.MarketingArea", "MarketingArea")
                        .WithMany("Stores")
                        .HasForeignKey("MarketingAreaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MarketingArea");
                });

            modelBuilder.Entity("OrderService.Data.Domain.Customer", b =>
                {
                    b.Navigation("SalesOrders");
                });

            modelBuilder.Entity("OrderService.Data.Domain.MarketingArea", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("OrderService.Data.Domain.ProductSparepart", b =>
                {
                    b.Navigation("SalesOrders");
                });

            modelBuilder.Entity("OrderService.Data.Domain.Store", b =>
                {
                    b.Navigation("ProductSpareparts");
                });
#pragma warning restore 612, 618
        }
    }
}
