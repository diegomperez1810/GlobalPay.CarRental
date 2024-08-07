﻿// <auto-generated />
using System;
using GlobalPay.CarRental.INF.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GlobalPay.CarRental.INF.DB.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    [Migration("20240626161757_init_project")]
    partial class init_project
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Mark")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Car", "Rental");
                });

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.CarHire", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ScheduledReturnDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Surcharge")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("FeeId");

                    b.ToTable("CarHire", "Rental");
                });

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.Fee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ExtraDaySurcharge")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid?>("FeeSurchargeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FeeSurchargeId");

                    b.ToTable("Fee", "Rental");
                });

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<Guid>("FeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("RateRatio")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("FeeId");

                    b.ToTable("Period", "Rental");
                });

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.CarHire", b =>
                {
                    b.HasOne("GlobalPay.CarRental.DOM.Entities.Car", "Car")
                        .WithMany("CarHires")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GlobalPay.CarRental.DOM.Entities.Fee", "Fee")
                        .WithMany("CarHires")
                        .HasForeignKey("FeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Fee");
                });

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.Fee", b =>
                {
                    b.HasOne("GlobalPay.CarRental.DOM.Entities.Fee", "FeeSurcharge")
                        .WithMany()
                        .HasForeignKey("FeeSurchargeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FeeSurcharge");
                });

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.Period", b =>
                {
                    b.HasOne("GlobalPay.CarRental.DOM.Entities.Fee", "Fee")
                        .WithMany("Periods")
                        .HasForeignKey("FeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fee");
                });

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.Car", b =>
                {
                    b.Navigation("CarHires");
                });

            modelBuilder.Entity("GlobalPay.CarRental.DOM.Entities.Fee", b =>
                {
                    b.Navigation("CarHires");

                    b.Navigation("Periods");
                });
#pragma warning restore 612, 618
        }
    }
}
