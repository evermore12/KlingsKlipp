﻿// <auto-generated />
using System;
using KlingsKlipp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KlingsKlipp.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20220604154840_AddedBookings")]
    partial class AddedBookings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KlingsKlipp.Data.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("TimeblockId")
                        .HasColumnType("int");

                    b.Property<int>("TreatmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TimeblockId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Day", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.HasKey("Date");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Timeblock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DayId")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("End")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("Start")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("Timeblocks");
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Booking", b =>
                {
                    b.HasOne("KlingsKlipp.Data.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KlingsKlipp.Data.Models.Timeblock", null)
                        .WithMany("Bookings")
                        .HasForeignKey("TimeblockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KlingsKlipp.Data.Models.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Timeblock", b =>
                {
                    b.HasOne("KlingsKlipp.Data.Models.Day", null)
                        .WithMany("Timeblocks")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Day", b =>
                {
                    b.Navigation("Timeblocks");
                });

            modelBuilder.Entity("KlingsKlipp.Data.Models.Timeblock", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
