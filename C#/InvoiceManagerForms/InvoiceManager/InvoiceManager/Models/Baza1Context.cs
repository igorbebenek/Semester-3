using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Models;

public partial class Baza1Context : DbContext
{
    public Baza1Context()
    {
    }

    public Baza1Context(DbContextOptions<Baza1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoicePo> InvoicePos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LEGION5;Initial Catalog=Baza1;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("pk_invoice");

            entity.ToTable("invoice");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("invoice_id");
            entity.Property(e => e.Number)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("value");
        });

        modelBuilder.Entity<InvoicePo>(entity =>
        {
            entity.HasKey(e => e.InvoicePosId).HasName("pk_invoice_pos");

            entity.ToTable("invoice_pos");

            entity.Property(e => e.InvoicePosId)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("invoice_pos_id");
            entity.Property(e => e.InvoiceId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("invoice_id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("value");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoicePos)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_invoice_pos");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
