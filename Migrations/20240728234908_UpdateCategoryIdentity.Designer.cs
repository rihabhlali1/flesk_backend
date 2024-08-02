﻿// <auto-generated />
using System;
using FleskBtocBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleskBtocBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240728234908_UpdateCategoryIdentity")]
    partial class UpdateCategoryIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FleskBtocBackend.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("FleskBtocBackend.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FleskBtocBackend.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("battery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("connectivity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("express")
                        .HasColumnType("bit");

                    b.Property<string>("features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("freeShippingThreshold")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("frontCamera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gtin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("highlights")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("longDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("newCustomerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("newCustomerDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("newCustomerLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("originalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("os")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("performance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("processor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("range")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("rearCamera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("reviewsCount")
                        .HasColumnType("int");

                    b.Property<string>("screen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("security")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shippingDestination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("shippingDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("sim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.Property<string>("storage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FleskBtocBackend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FleskBtocBackend.Models.CartItem", b =>
                {
                    b.HasOne("FleskBtocBackend.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleskBtocBackend.Models.User", null)
                        .WithMany("Cart")
                        .HasForeignKey("UserId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FleskBtocBackend.Models.Product", b =>
                {
                    b.HasOne("FleskBtocBackend.Models.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FleskBtocBackend.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FleskBtocBackend.Models.User", b =>
                {
                    b.Navigation("Cart");
                });
#pragma warning restore 612, 618
        }
    }
}
