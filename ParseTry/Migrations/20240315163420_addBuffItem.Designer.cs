﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParseTry.DBWorker;


#nullable disable

namespace ParseTry.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240315163420_addBuffItem")]
    partial class addBuffItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ParseTry.BuffParser.ItemBuff", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("buy_max_price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("buy_num")
                        .HasColumnType("int");

                    b.Property<string>("exterior_localized_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("market_hash_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_icon_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("quick_price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sell_min_price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sell_num")
                        .HasColumnType("int");

                    b.Property<string>("sell_reference_price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("steam_market_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("steam_price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("steam_price_cny")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type_localized_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("BuffItems");
                });

            modelBuilder.Entity("ParseTry.MarketParser.ItemMarket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("avg_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("buy_order")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("market_hash_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("popularity_7d")
                        .HasColumnType("int");

                    b.Property<decimal?>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ru_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ru_quality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ru_rarity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
