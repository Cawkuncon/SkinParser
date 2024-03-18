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
    [Migration("20240316181412_addResultItems")]
    partial class addResultItems
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
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("buy_max_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("buy_num")
                        .HasColumnType("int");

                    b.Property<string>("exterior_localized_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("market_hash_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_icon_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("quick_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("sell_min_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("sell_num")
                        .HasColumnType("int");

                    b.Property<string>("steam_market_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("steam_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("steam_price_cny")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("type_localized_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("url_buff")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BuffItems");
                });

            modelBuilder.Entity("ParseTry.Main.ResultItem", b =>
                {
                    b.Property<string>("hash_name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("buff_buy_max_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("buff_buy_num")
                        .HasColumnType("int");

                    b.Property<string>("buff_exterior_localized_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buff_original_icon_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("buff_sell_min_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("buff_sell_num")
                        .HasColumnType("int");

                    b.Property<string>("buff_steam_market_url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("buff_steam_price_cny")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("buff_type_localized_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("buff_url_buff")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("market_buy_order")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("market_popularity_7d")
                        .HasColumnType("int");

                    b.Property<decimal?>("market_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("market_url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hash_name");

                    b.ToTable("ResultItems");
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
