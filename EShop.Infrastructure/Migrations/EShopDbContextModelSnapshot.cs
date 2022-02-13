﻿// <auto-generated />
using EShop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EShop.Infrastructure.Migrations
{
    [DbContext(typeof(EShopDbContext))]
    partial class EShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

                    b.ToTable("Categories");
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

                    b.ToTable("Sellers");
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

                    b.ToTable("Status");

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

            modelBuilder.Entity("EShop.Domain.AggregatesModel.CategoryAggregateModel.Category", b =>
                {
                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("EShop.Domain.AggregatesModel.SellerAggregateModel.Seller", b =>
                {
                    b.HasOne("EShop.Domain.Core.Enumerations.EnumStatus", "Status")
                        .WithMany()
                        .HasForeignKey("_statusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
