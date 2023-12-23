﻿// <auto-generated />
using System;
using FootballGame.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTRS.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    [Migration("20231223110517_FM")]
    partial class FM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookingPassenger", b =>
                {
                    b.Property<int>("BookingsBookingID")
                        .HasColumnType("int");

                    b.Property<int>("PassengerID")
                        .HasColumnType("int");

                    b.HasKey("BookingsBookingID", "PassengerID");

                    b.HasIndex("PassengerID");

                    b.ToTable("BookingPassenger");
                });

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"), 1L, 1);

                    b.Property<string>("AdminFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AdminID");

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("admin");
                });

            modelBuilder.Entity("BTRS.Models.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"), 1L, 1);

                    b.Property<int>("PassengerID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.ToTable("booking");
                });

            modelBuilder.Entity("BTRS.Models.Bus", b =>
                {
                    b.Property<int>("BusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusID"), 1L, 1);

                    b.Property<string>("CaptainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfSeats")
                        .HasColumnType("int");

                    b.HasKey("BusID");

                    b.ToTable("bus");
                });

            modelBuilder.Entity("BTRS.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PassengerID");

                    b.ToTable("passenger");
                });

            modelBuilder.Entity("BTRS.Models.Passenger_Trips", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("PassengerID")
                        .HasColumnType("int");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PassengerID");

                    b.HasIndex("TripID");

                    b.ToTable("passenger_trips");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"), 1L, 1);

                    b.Property<int?>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("BusNumber")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TripID");

                    b.HasIndex("AdminID");

                    b.HasIndex("BusNumber")
                        .IsUnique();

                    b.ToTable("trip");
                });

            modelBuilder.Entity("BusTrip", b =>
                {
                    b.Property<int>("BusesBusID")
                        .HasColumnType("int");

                    b.Property<int>("TripsTripID")
                        .HasColumnType("int");

                    b.HasKey("BusesBusID", "TripsTripID");

                    b.HasIndex("TripsTripID");

                    b.ToTable("BusTrip");
                });

            modelBuilder.Entity("BookingPassenger", b =>
                {
                    b.HasOne("BTRS.Models.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingsBookingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTRS.Models.Passenger_Trips", b =>
                {
                    b.HasOne("BTRS.Models.Passenger", null)
                        .WithMany("passenger_trips")
                        .HasForeignKey("PassengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", "trip")
                        .WithMany("PassengerTrips")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.HasOne("BTRS.Models.Admin", null)
                        .WithMany("Trips")
                        .HasForeignKey("AdminID");
                });

            modelBuilder.Entity("BusTrip", b =>
                {
                    b.HasOne("BTRS.Models.Bus", null)
                        .WithMany()
                        .HasForeignKey("BusesBusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripsTripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("BTRS.Models.Passenger", b =>
                {
                    b.Navigation("passenger_trips");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.Navigation("PassengerTrips");
                });
#pragma warning restore 612, 618
        }
    }
}