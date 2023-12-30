﻿// <auto-generated />
using System;
using BTRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BTRS.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    partial class SystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BTRS.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusID"));

                    b.Property<string>("CaptainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.HasKey("BusID");

                    b.HasIndex("TripID");

                    b.ToTable("bus");
                });

            modelBuilder.Entity("BTRS.Models.Passenger", b =>
                {
                    b.Property<int>("PassengerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerID"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"));

                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("BusNumber")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SelectedSeats")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TripID");

                    b.HasIndex("AdminID");

                    b.HasIndex("BusNumber")
                        .IsUnique();

                    b.ToTable("trip");
                });

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

            modelBuilder.Entity("BTRS.Models.Bus", b =>
                {
                    b.HasOne("BTRS.Models.Trip", "trip")
                        .WithMany("Buses")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Passenger_Trips", b =>
                {
                    b.HasOne("BTRS.Models.Passenger", "passenger")
                        .WithMany("passenger_trips")
                        .HasForeignKey("PassengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTRS.Models.Trip", "trip")
                        .WithMany("PassengerTrips")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("passenger");

                    b.Navigation("trip");
                });

            modelBuilder.Entity("BTRS.Models.Trip", b =>
                {
                    b.HasOne("BTRS.Models.Admin", "Admin")
                        .WithMany("Trips")
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
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
                    b.Navigation("Buses");

                    b.Navigation("PassengerTrips");
                });
#pragma warning restore 612, 618
        }
    }
}
