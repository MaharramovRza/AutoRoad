using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AutoRoad.MVC.Models;

namespace AutoRoad.MVC.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarPhoto> CarPhotos { get; set; }

    public virtual DbSet<Fuel> Fuels { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Transmission> Transmissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Database:ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BANS");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnType("datetime");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BRANDS");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnType("datetime");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CARS");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Updated).HasColumnType("datetime");

            entity.HasOne(d => d.Ban).WithMany(p => p.Cars)
                .HasForeignKey(d => d.BanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cars_fk3");

            entity.HasOne(d => d.Fuel).WithMany(p => p.Cars)
                .HasForeignKey(d => d.FuelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cars_fk1");

            entity.HasOne(d => d.Model).WithMany(p => p.Cars)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cars_fk0");

            entity.HasOne(d => d.Transmission).WithMany(p => p.Cars)
                .HasForeignKey(d => d.TransmissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cars_fk2");
        });

        modelBuilder.Entity<CarPhoto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CARPHOTOS");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.IsMain)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnType("datetime");

            entity.HasOne(d => d.Car).WithMany(p => p.CarPhotos)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CarPhotos_fk0");
        });

        modelBuilder.Entity<Fuel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FUELS");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnType("datetime");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MODELS");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnType("datetime");

            entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Models_fk0");
        });

        modelBuilder.Entity<Transmission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TRANSMISSIONS");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_USERS");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.RegisterDate).HasColumnType("datetime");
            entity.Property(e => e.Surname).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnType("datetime");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_fk0");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_USERROLES");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
