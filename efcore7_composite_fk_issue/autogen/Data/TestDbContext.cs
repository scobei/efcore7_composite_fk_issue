using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using test.Data.Models;

namespace test.Data;

public partial class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaseTable> BaseTables { get; set; }

    public virtual DbSet<SubTable> SubTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseTable>(entity =>
        {
            entity.HasKey(e => e.BaseId).HasName("base_table_pkey");

            entity.Property(e => e.BaseId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SubTable>(entity =>
        {
            entity.HasKey(e => e.SubId).HasName("sub_table_pkey");

            entity.Property(e => e.SubId).ValueGeneratedNever();

            entity.HasOne(d => d.BaseTable).WithMany(p => p.SubTables)
                .HasPrincipalKey(p => new { p.BaseId, p.BaseTypeId })
                .HasConstraintName("fk_sub_base_one_to_one");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
