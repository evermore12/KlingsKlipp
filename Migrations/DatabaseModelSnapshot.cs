﻿// <auto-generated />
using System;
using KlingsKlipp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KlingsKlipp.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KlingsKlipp.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("TreatmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("KlingsKlipp.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("KlingsKlipp.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("KlingsKlipp.TimeBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int?>("DayId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.HasIndex("DayId");

                    b.ToTable("TimeBlocks");
                });

            modelBuilder.Entity("KlingsKlipp.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("KlingsKlipp.Booking", b =>
                {
                    b.HasOne("KlingsKlipp.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId");

                    b.HasOne("KlingsKlipp.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId");

                    b.Navigation("Customer");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("KlingsKlipp.TimeBlock", b =>
                {
                    b.HasOne("KlingsKlipp.Booking", "Booking")
                        .WithOne("TimeBlock")
                        .HasForeignKey("KlingsKlipp.TimeBlock", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KlingsKlipp.Day", null)
                        .WithMany("TimeBlocks")
                        .HasForeignKey("DayId");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("KlingsKlipp.Booking", b =>
                {
                    b.Navigation("TimeBlock");
                });

            modelBuilder.Entity("KlingsKlipp.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("KlingsKlipp.Day", b =>
                {
                    b.Navigation("TimeBlocks");
                });
#pragma warning restore 612, 618
        }
    }
}