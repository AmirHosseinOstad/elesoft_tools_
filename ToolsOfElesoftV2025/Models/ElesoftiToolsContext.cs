using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToolsOfElesoftV2025.Models;

public partial class ElesoftiToolsContext : DbContext
{
    public ElesoftiToolsContext()
    {
    }

    public ElesoftiToolsContext(DbContextOptions<ElesoftiToolsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tview> Tviews { get; set; }

    public virtual DbSet<Twork> Tworks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("[your connection string]");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("elesofti_Db");

        modelBuilder.Entity<Tview>(entity =>
        {
            entity.ToTable("TViews");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Deviece)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DevieceAsShort)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IpAddress)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Twork>(entity =>
        {
            entity.ToTable("TWorks");

            entity.Property(e => e.Date).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
