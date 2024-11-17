using System;
using System.Collections.Generic;
using Inc.MyFamily.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Inc.MyFamily.DAL.Context;

public partial class dbMyFamilyContext : DbContext
{
    public dbMyFamilyContext()
    {
    }

    public dbMyFamilyContext(DbContextOptions<dbMyFamilyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Family> Families { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DEV13,6001;Initial Catalog=dbMyFamily;persist security info=True;user id=sa;password=Toktok7652@;TrustServerCertificate=True;MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Children__3214EC0771FB9475");

            entity.HasOne(d => d.Family).WithMany(p => p.Children)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Children_Parents");
        });

        modelBuilder.Entity<Family>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Family__3214EC07D4BB8321");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Parents__3214EC07B818DBAF");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Family).WithMany(p => p.Parents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FamilyId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
