using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entity2;

public partial class BikeARContext : DbContext
{
    public BikeARContext()
    {
    }

    public BikeARContext(DbContextOptions<BikeARContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bike> Bikes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Opinion> Opinions { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderBike> OrderBikes { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PF2SAW12\\SQLEXPRESS;Initial Catalog=bike_a&r1;Integrated Security=True; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bike>(entity =>
        {
            entity.ToTable("bike");

            entity.HasIndex(e => e.IdStation, "IX_bike_idStation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Battery).HasColumnName("battery");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.DateStart).HasColumnType("date");
            entity.Property(e => e.IdStation).HasColumnName("idStation");

            entity.HasOne(d => d.IdStationNavigation).WithMany(p => p.Bikes)
                .HasForeignKey(d => d.IdStation)
                .HasConstraintName("FK_bike_stations");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("customers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.DateBirth)
                .HasColumnType("date")
                .HasColumnName("dateBirth");
            entity.Property(e => e.IsManager).HasColumnName("isManager");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Phon)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("phon");
            entity.Property(e => e.Pic)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("pic");
            entity.Property(e => e.ReadTerms).HasColumnName("readTerms");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Toun)
                .HasMaxLength(50)
                .HasColumnName("toun");
            entity.Property(e => e.Tz)
                .HasMaxLength(9)
                .HasColumnName("tz");
        });

        modelBuilder.Entity<Opinion>(entity =>
        {
            entity.ToTable("opinion");

            entity.HasIndex(e => e.IdStation, "IX_opinion_idStation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Caption)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("caption");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.IdCust).HasColumnName("idCust");
            entity.Property(e => e.IdStation).HasColumnName("idStation");
            entity.Property(e => e.SatisfactionLeve).HasColumnName("satisfactionLeve");

            entity.HasOne(d => d.IdStationNavigation).WithMany(p => p.Opinions)
                .HasForeignKey(d => d.IdStation)
                .HasConstraintName("FK_opinion_stations");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.HasIndex(e => e.IdCust, "IX_orders_idCust");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.DateOrder)
                .HasColumnType("date")
                .HasColumnName("dateOrder");
            entity.Property(e => e.DatePay)
                .HasColumnType("date")
                .HasColumnName("datePay");
            entity.Property(e => e.EndSum).HasColumnName("endSum");
            entity.Property(e => e.IdCust).HasColumnName("idCust");
            entity.Property(e => e.IdStation).HasColumnName("idStation");
            entity.Property(e => e.IsPay).HasColumnName("isPay");

            entity.HasOne(d => d.IdStationNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdStation)
                .HasConstraintName("FK_orders_stations");
        });

        modelBuilder.Entity<OrderBike>(entity =>
        {
            entity.ToTable("order_bike");

            entity.HasIndex(e => e.IdPay, "IX_order_bike_idPay");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateEnd)
                .HasColumnType("date")
                .HasColumnName("dateEnd");
            entity.Property(e => e.DateStart)
                .HasColumnType("date")
                .HasColumnName("dateStart");
            entity.Property(e => e.IdBike).HasColumnName("idBike");
            entity.Property(e => e.IdPay).HasColumnName("idPay");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Sum).HasColumnName("sum");

            entity.HasOne(d => d.IdBikeNavigation).WithMany(p => p.OrderBikes)
                .HasForeignKey(d => d.IdBike)
                .HasConstraintName("FK_order_bike_bike");

            entity.HasOne(d => d.IdPayNavigation).WithMany(p => p.OrderBikes)
                .HasForeignKey(d => d.IdPay)
                .HasConstraintName("FK_order_bike_orders");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.ToTable("stations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
