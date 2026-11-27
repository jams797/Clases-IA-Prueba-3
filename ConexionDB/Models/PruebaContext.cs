using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConexionDB.Models;

public partial class PruebaContext : DbContext
{
    public PruebaContext()
    {
    }

    public PruebaContext(DbContextOptions<PruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ciudad> Ciudades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sucursal> Sucursales { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=prueba;Username=admin;Password=Admin123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategId).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.Property(e => e.CategId).HasColumnName("categ_id");
            entity.Property(e => e.CategNombre)
                .HasMaxLength(150)
                .HasColumnName("categ_nombre");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora_reg");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.CiudadId).HasName("ciudad_pkey");

            entity.ToTable("ciudad");

            entity.Property(e => e.CiudadId).HasColumnName("ciudad_id");
            entity.Property(e => e.CiudadNombre)
                .HasMaxLength(150)
                .HasColumnName("ciudad_nombre");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora_reg");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .HasColumnName("cedula");
            entity.Property(e => e.ClienteNombre)
                .HasMaxLength(200)
                .HasColumnName("cliente_nombre");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora_reg");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("marca_pkey");

            entity.ToTable("marca");

            entity.Property(e => e.MarcaId).HasColumnName("marca_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora_reg");
            entity.Property(e => e.MarcaNombre)
                .HasMaxLength(150)
                .HasColumnName("marca_nombre");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.ModeloId).HasName("modelo_pkey");

            entity.ToTable("modelo");

            entity.Property(e => e.ModeloId).HasColumnName("modelo_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora_reg");
            entity.Property(e => e.ModeloDescrip)
                .HasMaxLength(200)
                .HasColumnName("modelo_descrip");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("producto_pkey");

            entity.ToTable("producto");

            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.CategId).HasColumnName("categ_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora_reg");
            entity.Property(e => e.MarcaId).HasColumnName("marca_id");
            entity.Property(e => e.ModeloId).HasColumnName("modelo_id");
            entity.Property(e => e.Precio)
                .HasPrecision(18, 2)
                .HasColumnName("precio");
            entity.Property(e => e.ProductoDescrip)
                .HasMaxLength(250)
                .HasColumnName("producto_descrip");

            entity.HasOne(d => d.Categ).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategId)
                .HasConstraintName("fk_categoria_producto");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("fk_marca_producto");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ModeloId)
                .HasConstraintName("fk_modelo_producto");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.SucursalId).HasName("sucursal_pkey");

            entity.ToTable("sucursal");

            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.CiudadId).HasColumnName("ciudad_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora_reg");
            entity.Property(e => e.SucursalNombre)
                .HasMaxLength(200)
                .HasColumnName("sucursal_nombre");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.CiudadId)
                .HasConstraintName("fk_ciudad_sucursal");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("ventas_pkey");

            entity.ToTable("ventas");

            entity.Property(e => e.VentaId).HasColumnName("venta_id");
            entity.Property(e => e.CajaId).HasColumnName("caja_id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FacturaId).HasColumnName("factura_id");
            entity.Property(e => e.FechaHora)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.NumFact)
                .HasMaxLength(50)
                .HasColumnName("num_fact");
            entity.Property(e => e.Precio)
                .HasPrecision(18, 2)
                .HasColumnName("precio");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.Unidades).HasColumnName("unidades");
            entity.Property(e => e.VendedorId).HasColumnName("vendedor_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("fk_cliente_ventas");

            entity.HasOne(d => d.Producto).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("fk_producto_ventas");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Venta)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("fk_sucursal_ventas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
