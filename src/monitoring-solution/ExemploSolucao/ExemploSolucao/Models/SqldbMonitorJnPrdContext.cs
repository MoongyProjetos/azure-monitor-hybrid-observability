using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExemploSolucao.Models;

public partial class SqldbMonitorJnPrdContext : DbContext
{
    public SqldbMonitorJnPrdContext()
    {
    }

    public SqldbMonitorJnPrdContext(DbContextOptions<SqldbMonitorJnPrdContext> options) : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<RateCode> RateCodes { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=tcp:sql-monitor-jn-prd.database.windows.net,1433;Initial Catalog=sqldb-monitor-jn-prd;Persist Security Info=False;User ID=sqladmin;Password=abc,1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=300;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.LocationId).ValueGeneratedNever();
            entity.Property(e => e.Borough).HasMaxLength(100);
            entity.Property(e => e.LocationName).HasMaxLength(150);
            entity.Property(e => e.ServiceZone).HasMaxLength(100);
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.ToTable("PaymentType");

            entity.Property(e => e.PaymentTypeId).ValueGeneratedNever();
            entity.Property(e => e.PaymentTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<RateCode>(entity =>
        {
            entity.ToTable("RateCode");

            entity.Property(e => e.RateCodeId).ValueGeneratedNever();
            entity.Property(e => e.RateCodeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.ToTable("Trip");

            entity.HasIndex(e => e.DropoffLocationId, "IX_Trip_DropoffLocation");

            entity.HasIndex(e => e.PickupDateTime, "IX_Trip_PickupDateTime");

            entity.HasIndex(e => e.PickupLocationId, "IX_Trip_PickupLocation");

            entity.HasIndex(e => e.VendorId, "IX_Trip_Vendor");

            entity.Property(e => e.DropoffDateTime).HasPrecision(3);
            entity.Property(e => e.EndLat).HasColumnType("decimal(10, 7)");
            entity.Property(e => e.EndLon).HasColumnType("decimal(11, 7)");
            entity.Property(e => e.Extra).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.FareAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.ImprovementSurcharge).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.MtaTax).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.PickupDateTime).HasPrecision(3);
            entity.Property(e => e.StartLat).HasColumnType("decimal(10, 7)");
            entity.Property(e => e.StartLon).HasColumnType("decimal(11, 7)");
            entity.Property(e => e.StoreAndFwdFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TipAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TollsAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TripDistance).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.DropoffLocation).WithMany(p => p.TripDropoffLocations)
                .HasForeignKey(d => d.DropoffLocationId)
                .HasConstraintName("FK_Trip_DropoffLocation");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Trips)
                .HasForeignKey(d => d.PaymentTypeId)
                .HasConstraintName("FK_Trip_PaymentType");

            entity.HasOne(d => d.PickupLocation).WithMany(p => p.TripPickupLocations)
                .HasForeignKey(d => d.PickupLocationId)
                .HasConstraintName("FK_Trip_PickupLocation");

            entity.HasOne(d => d.RateCode).WithMany(p => p.Trips)
                .HasForeignKey(d => d.RateCodeId)
                .HasConstraintName("FK_Trip_RateCode");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Trips)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trip_Vendor");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.ToTable("Vendor");

            entity.Property(e => e.VendorId).ValueGeneratedNever();
            entity.Property(e => e.VendorName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
