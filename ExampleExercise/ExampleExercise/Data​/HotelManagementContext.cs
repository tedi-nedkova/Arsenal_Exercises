﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExampleExercise.Data​;

public partial class HotelManagementContext : DbContext
{
    public HotelManagementContext()
    {
    }

    public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=hotel_management;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__guests__3213E83FFDA283FF");

            entity.ToTable("guests");

            entity.HasIndex(e => e.Ucn, "UQ__guests__C5B186D2D9C7CE6B").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Ucn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("UCN");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservat__3213E83F229CF984");

            entity.ToTable("reservations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccommodationDate).HasColumnName("accommodation_date");
            entity.Property(e => e.Days).HasColumnName("days");
            entity.Property(e => e.GuestId).HasColumnName("guest_id");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.GuestId)
                .HasConstraintName("FK__reservati__guest__403A8C7D");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__reservati__room___3F466844");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rooms__3213E83FD8670FD5");

            entity.ToTable("rooms");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .HasConstraintName("FK__rooms__room_type__3C69FB99");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__room_typ__3213E83FC059408A");

            entity.ToTable("room_types");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.MaxCapacity).HasColumnName("max_capacity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
