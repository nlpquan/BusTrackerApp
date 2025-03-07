﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace BusTrackerBackend.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20250307013836_DatabaseCreation")]
    partial class DatabaseCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Bus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BusId");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<double>("CurrentLatitude")
                        .HasColumnType("float");

                    b.Property<double>("CurrentLongitude")
                        .HasColumnType("float");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("Entities.Models.BusStop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("BusStopId");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longtitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("BusStops");
                });

            modelBuilder.Entity("Entities.Models.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RouteId");

                    b.Property<Guid?>("BusesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EndPoint")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("StartPoint")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("BusesId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Entities.Models.RouteStop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RouteStopId");

                    b.Property<Guid>("BusStopId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BusStopOrder")
                        .HasColumnType("int");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BusStopId");

                    b.HasIndex("RouteId");

                    b.ToTable("RouteStops");
                });

            modelBuilder.Entity("Entities.Models.TrackingHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TrackingId");

                    b.Property<Guid>("BusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longtitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("TrackingHistories");
                });

            modelBuilder.Entity("Entities.Models.Route", b =>
                {
                    b.HasOne("Entities.Models.Bus", "Buses")
                        .WithMany("Routes")
                        .HasForeignKey("BusesId");

                    b.Navigation("Buses");
                });

            modelBuilder.Entity("Entities.Models.RouteStop", b =>
                {
                    b.HasOne("Entities.Models.BusStop", "BusStops")
                        .WithMany("RouteStops")
                        .HasForeignKey("BusStopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Route", "Routes")
                        .WithMany("RouteStops")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusStops");

                    b.Navigation("Routes");
                });

            modelBuilder.Entity("Entities.Models.TrackingHistory", b =>
                {
                    b.HasOne("Entities.Models.Bus", "Buses")
                        .WithMany("TrackingHistories")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buses");
                });

            modelBuilder.Entity("Entities.Models.Bus", b =>
                {
                    b.Navigation("Routes");

                    b.Navigation("TrackingHistories");
                });

            modelBuilder.Entity("Entities.Models.BusStop", b =>
                {
                    b.Navigation("RouteStops");
                });

            modelBuilder.Entity("Entities.Models.Route", b =>
                {
                    b.Navigation("RouteStops");
                });
#pragma warning restore 612, 618
        }
    }
}
