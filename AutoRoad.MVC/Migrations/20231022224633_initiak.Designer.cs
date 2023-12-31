﻿// <auto-generated />
using System;
using AutoRoad.MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoRoad.MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231022224633_initiak")]
    partial class initiak
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoRoad.MVC.Models.Ban", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_BANS");

                    b.ToTable("Bans");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_BRANDS");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BanId")
                        .HasColumnType("int");

                    b.Property<int>("CarCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<int>("Doors")
                        .HasColumnType("int");

                    b.Property<int>("FuelId")
                        .HasColumnType("int");

                    b.Property<bool>("HasGarage")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("TransmissionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_CARS");

                    b.HasIndex("BanId");

                    b.HasIndex("FuelId");

                    b.HasIndex("ModelId");

                    b.HasIndex("TransmissionId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.CarPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_CARPHOTOS");

                    b.HasIndex("CarId");

                    b.ToTable("CarPhotos");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Fuel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_FUELS");

                    b.ToTable("Fuels");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_MODELS");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Transmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_TRANSMISSIONS");

                    b.ToTable("Transmissions");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varbinary(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime?>("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_USERS");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime");

                    b.HasKey("Id")
                        .HasName("PK_USERROLES");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Car", b =>
                {
                    b.HasOne("AutoRoad.MVC.Models.Ban", "Ban")
                        .WithMany("Cars")
                        .HasForeignKey("BanId")
                        .IsRequired()
                        .HasConstraintName("Cars_fk3");

                    b.HasOne("AutoRoad.MVC.Models.Fuel", "Fuel")
                        .WithMany("Cars")
                        .HasForeignKey("FuelId")
                        .IsRequired()
                        .HasConstraintName("Cars_fk1");

                    b.HasOne("AutoRoad.MVC.Models.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId")
                        .IsRequired()
                        .HasConstraintName("Cars_fk0");

                    b.HasOne("AutoRoad.MVC.Models.Transmission", "Transmission")
                        .WithMany("Cars")
                        .HasForeignKey("TransmissionId")
                        .IsRequired()
                        .HasConstraintName("Cars_fk2");

                    b.Navigation("Ban");

                    b.Navigation("Fuel");

                    b.Navigation("Model");

                    b.Navigation("Transmission");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.CarPhoto", b =>
                {
                    b.HasOne("AutoRoad.MVC.Models.Car", "Car")
                        .WithMany("CarPhotos")
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("CarPhotos_fk0");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Model", b =>
                {
                    b.HasOne("AutoRoad.MVC.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .IsRequired()
                        .HasConstraintName("Models_fk0");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.User", b =>
                {
                    b.HasOne("AutoRoad.MVC.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .IsRequired()
                        .HasConstraintName("Users_fk0");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Ban", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Car", b =>
                {
                    b.Navigation("CarPhotos");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Fuel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Model", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.Transmission", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoRoad.MVC.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
