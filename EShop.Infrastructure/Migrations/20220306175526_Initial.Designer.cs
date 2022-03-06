﻿// <auto-generated />
using System;
using EShop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EShop.Infrastructure.Migrations
{
    [DbContext(typeof(EShopDbContext))]
    [Migration("20220306175526_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EShop.Domain.AggregatesModel.BasketAggregateModel.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BasketItem")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("ExcludesTaxPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("IncludingTaxPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("BasketItem");

                    b.HasIndex("_statusId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.BasketAggregateModel.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<decimal>("ExcludesTaxPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("IncludingTaxPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("SellerName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("StatusId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.CategoryAggregateModel.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("_statusId");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.CustomerAggregateModel.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("_statusId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.CustomerAggregateModel.CustomerAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("_statusId");

                    b.ToTable("CustomerAddresses");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.ProductAggregateModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.HasIndex("_statusId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.ProductAggregateModel.ProductAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("_statusId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.ProductAggregateModel.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("_statusId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.SellerAggregateModel.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("_statusId")
                        .HasColumnType("int")
                        .HasColumnName("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("_statusId");

                    b.ToTable("Sellers", (string)null);
                });

            modelBuilder.Entity("EShop.Domain.Core.Enumerations.EnumStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pasif"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Aktif"
                        });
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.BasketAggregateModel.Basket", b =>
                {
                    b.HasOne("EShop.Domain.AggregatesModel.BasketAggregateModel.BasketItem", null)
                        .WithMany()
                        .HasForeignKey("BasketItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.BasketAggregateModel.BasketItem", b =>
                {
                    b.HasOne("EShop.Domain.AggregatesModel.BasketAggregateModel.Basket", null)
                        .WithMany("BasketItems")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.CategoryAggregateModel.Category", b =>
                {
                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.CustomerAggregateModel.Customer", b =>
                {
                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.CustomerAggregateModel.CustomerAddress", b =>
                {
                    b.HasOne("EShop.Domain.AggregatesModel.CustomerAggregateModel.Customer", null)
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("CustomerId");

                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.ProductAggregateModel.Product", b =>
                {
                    b.HasOne("EShop.Domain.AggregatesModel.SellerAggregateModel.Seller", null)
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.ProductAggregateModel.ProductAttribute", b =>
                {
                    b.HasOne("EShop.Domain.AggregatesModel.ProductAggregateModel.Product", null)
                        .WithMany("Attributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.ProductAggregateModel.ProductCategory", b =>
                {
                    b.HasOne("EShop.Domain.AggregatesModel.CategoryAggregateModel.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Domain.AggregatesModel.ProductAggregateModel.Product", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.SellerAggregateModel.Seller", b =>
                {
                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.BasketAggregateModel.Basket", b =>
                {
                    b.Navigation("BasketItems");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.CustomerAggregateModel.Customer", b =>
                {
                    b.Navigation("CustomerAddresses");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.ProductAggregateModel.Product", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}