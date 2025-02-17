﻿// <auto-generated />
using System;
using Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastracture.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250217122720_AddIdentityUser")]
    partial class AddIdentityUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("brands_pkey");

                    b.HasIndex(new[] { "Name" }, "brands_name_key")
                        .IsUnique();

                    b.ToTable("brands", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("categories_pkey");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Data.Entities.DealType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("deal_types_pkey");

                    b.HasIndex(new[] { "Name" }, "deal_types_name_key")
                        .IsUnique();

                    b.ToTable("deal_types", (string)null);
                });

            modelBuilder.Entity("Data.Entities.DiscountRule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal?>("DiscountPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("discount_price");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("end_date");

                    b.Property<int?>("MinQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("min_quantity");

                    b.Property<long?>("ProductDetailId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_detail_id");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("start_date");

                    b.HasKey("Id")
                        .HasName("discount_rules_pkey");

                    b.HasIndex(new[] { "ProductDetailId" }, "idx_discount_rules_product_detail_id");

                    b.ToTable("discount_rules", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id")
                        .HasName("users_pkey");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex(new[] { "Email" }, "users_email_key")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Inventory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_updated");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("inventories_pkey");

                    b.ToTable("inventories", (string)null);
                });

            modelBuilder.Entity("Data.Entities.InventoryDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date");

                    b.Property<long?>("InventoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("inventory_id");

                    b.Property<long?>("ProductDetailsId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_details_id");

                    b.HasKey("Id")
                        .HasName("inventory_details_pkey");

                    b.HasIndex(new[] { "InventoryId" }, "idx_inventory_details_inventory_id");

                    b.HasIndex(new[] { "ProductDetailsId" }, "idx_inventory_details_product_details_id");

                    b.ToTable("inventory_details", (string)null);
                });

            modelBuilder.Entity("Data.Entities.InvoiceItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal?>("DiscountPercentage")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("discount_percentage");

                    b.Property<long?>("ProductDetailId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_detail_id");

                    b.Property<int?>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<long?>("SaleId")
                        .HasColumnType("bigint")
                        .HasColumnName("sale_id");

                    b.Property<long?>("SaleTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("sale_type_id");

                    b.Property<decimal?>("Subtotal")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("subtotal");

                    b.HasKey("Id")
                        .HasName("invoice_items_pkey");

                    b.HasIndex(new[] { "ProductDetailId" }, "idx_invoice_items_product_detail_id");

                    b.HasIndex(new[] { "SaleId" }, "idx_invoice_items_sale_id");

                    b.HasIndex(new[] { "SaleTypeId" }, "idx_invoice_items_sale_type_id");

                    b.ToTable("invoice_items", (string)null);
                });

            modelBuilder.Entity("Data.Entities.PaymentMethod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("method_name");

                    b.HasKey("Id")
                        .HasName("payment_methods_pkey");

                    b.HasIndex(new[] { "MethodName" }, "payment_methods_method_name_key")
                        .IsUnique();

                    b.ToTable("payment_methods", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Pricing", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("CostPerUnit")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("cost_per_unit");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("end_date");

                    b.Property<decimal>("PricePerUnit")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("price_per_unit");

                    b.Property<long?>("ProductDetailsId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_details_id");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("start_date");

                    b.Property<decimal>("TaxPercentage")
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasColumnName("tax_percentage");

                    b.HasKey("Id")
                        .HasName("pricing_pkey");

                    b.HasIndex(new[] { "ProductDetailsId" }, "idx_pricing_product_details_id");

                    b.ToTable("pricing", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("BrandId")
                        .HasColumnType("bigint")
                        .HasColumnName("brand_id");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long?>("UnitTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("unit_type_id");

                    b.HasKey("Id")
                        .HasName("products_pkey");

                    b.HasIndex(new[] { "BrandId" }, "idx_products_brand_id");

                    b.HasIndex(new[] { "CategoryId" }, "idx_products_category_id");

                    b.HasIndex(new[] { "UnitTypeId" }, "idx_products_unit_type_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Data.Entities.ProductDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("barcode");

                    b.Property<DateOnly?>("ExpirationDate")
                        .HasColumnType("date")
                        .HasColumnName("expiration_date");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<string>("Size")
                        .HasColumnType("text")
                        .HasColumnName("size");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("stock_quantity");

                    b.Property<string>("Variation")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("variation");

                    b.HasKey("Id")
                        .HasName("product_details_pkey");

                    b.HasIndex(new[] { "ProductId" }, "idx_product_details_product_id");

                    b.HasIndex(new[] { "Barcode" }, "product_details_barcode_key")
                        .IsUnique();

                    b.ToTable("product_details", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Sale", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("date");

                    b.Property<long>("DealTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("deal_type_id");

                    b.Property<string>("MarketName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("market_name");

                    b.Property<long>("PaymentMethodId")
                        .HasColumnType("bigint")
                        .HasColumnName("payment_method_id");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasColumnName("total_price");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("sales_pkey");

                    b.HasIndex(new[] { "DealTypeId" }, "idx_sales_deal_type_id");

                    b.HasIndex(new[] { "PaymentMethodId" }, "idx_sales_payment_method_id");

                    b.HasIndex(new[] { "UserId" }, "idx_sales_user_id");

                    b.ToTable("sales", (string)null);
                });

            modelBuilder.Entity("Data.Entities.SaleType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("sale_types_pkey");

                    b.HasIndex(new[] { "Name" }, "sale_types_name_key")
                        .IsUnique();

                    b.ToTable("sale_types", (string)null);
                });

            modelBuilder.Entity("Data.Entities.UnitType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("unit_types_pkey");

                    b.HasIndex(new[] { "Name" }, "unit_types_name_key")
                        .IsUnique();

                    b.ToTable("unit_types", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Entities.DiscountRule", b =>
                {
                    b.HasOne("Data.Entities.ProductDetail", "ProductDetail")
                        .WithMany("DiscountRules")
                        .HasForeignKey("ProductDetailId")
                        .HasConstraintName("discount_rules_product_detail_id_fkey");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("Data.Entities.InventoryDetail", b =>
                {
                    b.HasOne("Data.Entities.Inventory", "Inventory")
                        .WithMany("InventoryDetails")
                        .HasForeignKey("InventoryId")
                        .HasConstraintName("inventory_details_inventory_id_fkey");

                    b.HasOne("Data.Entities.ProductDetail", "ProductDetails")
                        .WithMany("InventoryDetails")
                        .HasForeignKey("ProductDetailsId")
                        .HasConstraintName("inventory_details_product_details_id_fkey");

                    b.Navigation("Inventory");

                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("Data.Entities.InvoiceItem", b =>
                {
                    b.HasOne("Data.Entities.ProductDetail", "ProductDetail")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("ProductDetailId")
                        .HasConstraintName("invoice_items_product_detail_id_fkey");

                    b.HasOne("Data.Entities.Sale", "Sale")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("SaleId")
                        .HasConstraintName("invoice_items_sale_id_fkey");

                    b.HasOne("Data.Entities.SaleType", "SaleType")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("SaleTypeId")
                        .HasConstraintName("invoice_items_sale_type_id_fkey");

                    b.Navigation("ProductDetail");

                    b.Navigation("Sale");

                    b.Navigation("SaleType");
                });

            modelBuilder.Entity("Data.Entities.Pricing", b =>
                {
                    b.HasOne("Data.Entities.ProductDetail", "ProductDetails")
                        .WithMany("Pricings")
                        .HasForeignKey("ProductDetailsId")
                        .HasConstraintName("pricing_product_details_id_fkey");

                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.HasOne("Data.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("products_brand_id_fkey");

                    b.HasOne("Data.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("products_category_id_fkey");

                    b.HasOne("Data.Entities.UnitType", "UnitType")
                        .WithMany("Products")
                        .HasForeignKey("UnitTypeId")
                        .HasConstraintName("products_unit_type_id_fkey");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("UnitType");
                });

            modelBuilder.Entity("Data.Entities.ProductDetail", b =>
                {
                    b.HasOne("Data.Entities.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_details_product_id_fkey");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Data.Entities.Sale", b =>
                {
                    b.HasOne("Data.Entities.DealType", "DealType")
                        .WithMany("Sales")
                        .HasForeignKey("DealTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("sales_deal_type_id_fkey");

                    b.HasOne("Data.Entities.PaymentMethod", "PaymentMethod")
                        .WithMany("Sales")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("sales_payment_method_id_fkey");

                    b.HasOne("Data.Entities.Identity.User", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("sales_user_id_fkey");

                    b.Navigation("DealType");

                    b.Navigation("PaymentMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Data.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Data.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Data.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Data.Entities.DealType", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Data.Entities.Identity.User", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Data.Entities.Inventory", b =>
                {
                    b.Navigation("InventoryDetails");
                });

            modelBuilder.Entity("Data.Entities.PaymentMethod", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("Data.Entities.ProductDetail", b =>
                {
                    b.Navigation("DiscountRules");

                    b.Navigation("InventoryDetails");

                    b.Navigation("InvoiceItems");

                    b.Navigation("Pricings");
                });

            modelBuilder.Entity("Data.Entities.Sale", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("Data.Entities.SaleType", b =>
                {
                    b.Navigation("InvoiceItems");
                });

            modelBuilder.Entity("Data.Entities.UnitType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
