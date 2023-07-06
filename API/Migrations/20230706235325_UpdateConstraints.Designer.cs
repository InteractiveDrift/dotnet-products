﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20230706235325_UpdateConstraints")]
    partial class UpdateConstraints
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("API.Models.Producer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AlcoholContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AssortmentCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("AssortmentText")
                        .HasColumnType("TEXT");

                    b.Property<string>("Deposit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long?>("Discontinued")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Ethical")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Kosher")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("Organic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Origin")
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginCountryName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Packaging")
                        .HasColumnType("TEXT");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PricePerLiter")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("ProducerId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ProductGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RawMaterialsDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("SalesStart")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SealType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Style")
                        .HasColumnType("TEXT");

                    b.Property<long>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<long?>("Vintage")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("VolymInml")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ProducerId" }, "IX_Products_ProducerId");

                    b.HasIndex(new[] { "ProductGroupId" }, "IX_Products_ProductGroupId");

                    b.HasIndex(new[] { "SupplierId" }, "IX_Products_SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.Models.ProductGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("API.Models.Supplier", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.HasOne("API.Models.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Producer");

                    b.Navigation("ProductGroup");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("API.Models.Producer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Models.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("API.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
