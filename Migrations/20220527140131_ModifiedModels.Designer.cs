﻿// <auto-generated />
using System;
using KlingsKlipp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KlingsKlipp.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20220527140131_ModifiedModels")]
    partial class ModifiedModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KlingsKlipp.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("TreatmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DayId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("KlingsKlipp.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("KlingsKlipp.Day", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("End")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Start")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("KlingsKlipp.Treatment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.HasOne("KlingsKlipp.Day", "Day")
                        .WithMany("Bookings")
                        .HasForeignKey("DayId");

                    b.HasOne("KlingsKlipp.Treatment", "Treatment")
                        .WithMany()
                        .HasForeignKey("TreatmentId");

                    b.Navigation("Customer");

                    b.Navigation("Day");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("KlingsKlipp.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("KlingsKlipp.Day", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
