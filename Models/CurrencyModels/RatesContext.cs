using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExchangeTrafik.Models.CurrencyModels;

public partial class RatesContext : DbContext
{
    public RatesContext()
    {
    }

    public RatesContext(DbContextOptions<RatesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Rates;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Option>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Headers).HasMaxLength(255);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Setting1).HasMaxLength(255);
            entity.Property(e => e.Setting2).HasMaxLength(255);
            entity.Property(e => e.Setting3).HasMaxLength(255);
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<TransactionLog>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.RequestUrl)
                .HasMaxLength(1000)
                .HasColumnName("RequestURL");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
