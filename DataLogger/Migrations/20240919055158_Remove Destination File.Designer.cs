﻿// <auto-generated />
using System;
using DataLogger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLogger.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240919055158_Remove Destination File")]
    partial class RemoveDestinationFile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataLogger.Models.PipesData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<float?>("CL")
                        .HasColumnType("real");

                    b.Property<float?>("Discharge")
                        .HasColumnType("real");

                    b.Property<float?>("ElectricConductivity")
                        .HasColumnType("real");

                    b.Property<float?>("Pressure")
                        .HasColumnType("real");

                    b.Property<long>("StationId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("TimeStamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("TotalVolumePerDay")
                        .HasColumnType("real");

                    b.Property<float?>("TotalVolumePerHour")
                        .HasColumnType("real");

                    b.Property<float?>("Turbidity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("PipesData");
                });

            modelBuilder.Entity("DataLogger.Models.Station", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ExternalId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceFile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("DataLogger.Models.PipesData", b =>
                {
                    b.HasOne("DataLogger.Models.Station", "Station")
                        .WithMany("PipesData")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("DataLogger.Models.Station", b =>
                {
                    b.Navigation("PipesData");
                });
#pragma warning restore 612, 618
        }
    }
}
