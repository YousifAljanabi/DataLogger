﻿// <auto-generated />
using System;
using DataLoggerDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLoggerDatabase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240928091513_update")]
    partial class update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataLoggerDatabase.Models.PipesData", b =>
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

                    b.Property<int>("Record")
                        .HasColumnType("integer");

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

            modelBuilder.Entity("DataLoggerDatabase.Models.Station", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DataFile")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ExternalId")
                        .HasColumnType("text");

                    b.Property<double?>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double?>("Lng")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("SourceAddress")
                        .HasColumnType("text");

                    b.Property<string>("UploadedDataFile")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("DataLoggerDatabase.Models.TankData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<float?>("ElectricConductivity")
                        .HasColumnType("real");

                    b.Property<int>("Record")
                        .HasColumnType("integer");

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

                    b.Property<float?>("WL")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("StationId");

                    b.ToTable("TankData");
                });

            modelBuilder.Entity("DataLoggerDatabase.Models.PipesData", b =>
                {
                    b.HasOne("DataLoggerDatabase.Models.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("DataLoggerDatabase.Models.TankData", b =>
                {
                    b.HasOne("DataLoggerDatabase.Models.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });
#pragma warning restore 612, 618
        }
    }
}
