using System;
using System.Collections.Generic;
using ISLAGO.Entidad.Models;
using Microsoft.EntityFrameworkCore;
using MigracionesBDISLAGO.Models;

namespace ISLAGO.Datos.DBContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Detfactura> Detfacturas { get; set; }

    public virtual DbSet<Detfacturatmp> Detfacturatmps { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Twofactorauth> Twofactorauths { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("articulo_pkey");

            entity.ToTable("articulo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Existencia).HasColumnName("existencia");
            entity.Property(e => e.Fechaingreso)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaingreso");
            entity.Property(e => e.Fechavencimiento)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechavencimiento");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Impuestos).HasColumnName("impuestos");
            entity.Property(e => e.Nombart)
                .HasMaxLength(100)
                .HasColumnName("nombart");
            entity.Property(e => e.Pcompra).HasColumnName("pcompra");
            entity.Property(e => e.Pventa).HasColumnName("pventa");
            entity.Property(e => e.Umedidas)
                .HasMaxLength(25)
                .HasColumnName("umedidas");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_categoria");

            entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.Articulos)
                .HasForeignKey(d => d.Idproveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_proveedor");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Nombcat)
                .HasMaxLength(75)
                .HasColumnName("nombcat");
        });

        modelBuilder.Entity<Detfactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detfactura_pkey");

            entity.ToTable("detfactura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Garantia)
                .HasMaxLength(150)
                .HasColumnName("garantia");
            entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");
            entity.Property(e => e.Idfactura).HasColumnName("idfactura");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Pventa).HasColumnName("pventa");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.IdarticuloNavigation).WithMany(p => p.Detfacturas)
                .HasForeignKey(d => d.Idarticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_articulo");

            entity.HasOne(d => d.IdfacturaNavigation).WithMany(p => p.Detfacturas)
                .HasForeignKey(d => d.Idfactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_factura");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Detfacturas)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<Detfacturatmp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detfacturatmp_pkey");

            entity.ToTable("detfacturatmp");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Garantia)
                .HasMaxLength(150)
                .HasColumnName("garantia");
            entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");
            entity.Property(e => e.Idfactura).HasColumnName("idfactura");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Pventa).HasColumnName("pventa");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.IdarticuloNavigation).WithMany(p => p.Detfacturatmps)
                .HasForeignKey(d => d.Idarticulo)
                .HasConstraintName("fk_articulo");

            entity.HasOne(d => d.IdfacturaNavigation).WithMany(p => p.Detfacturatmps)
                .HasForeignKey(d => d.Idfactura)
                .HasConstraintName("fk_factura");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Detfacturatmps)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("factura_pkey");

            entity.ToTable("factura");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anulada)
                .HasDefaultValue(false)
                .HasColumnName("anulada");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Nombcliente)
                .HasMaxLength(70)
                .HasColumnName("nombcliente");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empleado_pkey");

            entity.ToTable("persona");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('empleado_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(60)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(75)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fechanac)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechanac");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Primerapellido)
                .HasMaxLength(50)
                .HasColumnName("primerapellido");
            entity.Property(e => e.Primernombre)
                .HasMaxLength(50)
                .HasColumnName("primernombre");
            entity.Property(e => e.Segundoapellido)
                .HasMaxLength(50)
                .HasColumnName("segundoapellido");
            entity.Property(e => e.Segundonombre)
                .HasMaxLength(50)
                .HasColumnName("segundonombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("idRol");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proveedor_pkey");

            entity.ToTable("proveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Municipio)
                .HasMaxLength(54)
                .HasColumnName("municipio");
            entity.Property(e => e.Nombnegocio)
                .HasMaxLength(35)
                .HasColumnName("nombnegocio");
            entity.Property(e => e.Telefono)
                .HasMaxLength(25)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rol_pkey");

            entity.ToTable("rol");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Nombrol)
                .HasMaxLength(50)
                .HasColumnName("nombrol");
        });

        modelBuilder.Entity<Twofactorauth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("twofactorauth_pkey");

            entity.ToTable("twofactorauth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Expiracion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expiracion");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Method)
                .HasMaxLength(20)
                .HasColumnName("method");
            entity.Property(e => e.Token)
                .HasMaxLength(6)
                .HasColumnName("token");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Twofactorauths)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Idempleado).HasColumnName("idempleado");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");

            entity.HasOne(d => d.IdempleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idempleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empleado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
