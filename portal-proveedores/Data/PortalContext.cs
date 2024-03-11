using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using portal_proveedores.Models;

namespace portal_proveedores.Data;

public partial class PortalContext : DbContext
{
    public PortalContext()
    {
    }

    public PortalContext(DbContextOptions<PortalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<SolicitudCompra> SolicitudCompras { get; set; }

    public virtual DbSet<SolicitudCompraDet> SolicitudCompraDets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=portal;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("producto");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodProducto).HasColumnName("codProducto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Ruc);

            entity.ToTable("proveedor");

            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ruc");
            entity.Property(e => e.Contacto)
                .HasMaxLength(200)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Partnership).HasColumnName("partnership");
        });

        modelBuilder.Entity<SolicitudCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("solicitud_compra");

            entity.Property(e => e.CodSolCom)
                .ValueGeneratedOnAdd()
                .HasColumnName("codSolCom");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.RucProveedor)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rucProveedor");
        });

        modelBuilder.Entity<SolicitudCompraDet>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("solicitud_compra_det");

            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodProducto).HasColumnName("codProducto");
            entity.Property(e => e.CodSolCom).HasColumnName("codSolCom");
            entity.Property(e => e.CodSolComDet)
                .ValueGeneratedOnAdd()
                .HasColumnName("codSolComDet");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.NroDoc);

            entity.ToTable("usuario");

            entity.Property(e => e.NroDoc)
                .HasMaxLength(11)
                .HasColumnName("nroDoc");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .HasColumnName("clave");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(200)
                .HasColumnName("nombreCompleto");
            entity.Property(e => e.Perfil)
                .HasMaxLength(50)
                .HasColumnName("perfil");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
