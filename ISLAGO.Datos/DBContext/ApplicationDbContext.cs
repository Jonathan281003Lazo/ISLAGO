using System;
using System.Collections.Generic;
using ISLAGO.Entidad.Models;
using Microsoft.EntityFrameworkCore;

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
    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Detfactura> Detfacturas { get; set; }

    public virtual DbSet<Detfacturatmp> Detfacturatmps { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<ISLAGO.Entidad.Models.Negocio> Negocios { get; set; }

    public virtual DbSet<Numerocorrelativo> Numerocorrelativos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Rolmenu> Rolmenus { get; set; }

    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    public virtual DbSet<Tipodocumentoventum> Tipodocumentoventa { get; set; }

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
            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(100)
                .HasColumnName("codigoBarra");
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

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity.HasKey(e => e.Recurso).HasName("configuracion_pkey");

            entity.ToTable("configuracion");

            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .HasColumnName("recurso");
            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .HasColumnName("propiedad");
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .HasColumnName("valor");
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
            entity.Property(e => e.IdTipoDocumento).HasColumnName("idTipoDocumento");
            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Nombcliente)
                .HasMaxLength(70)
                .HasColumnName("nombcliente");
            entity.Property(e => e.Numeroventa)
                .HasMaxLength(6)
                .HasColumnName("numeroventa");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("fk_tipodocventa");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Idusuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuario");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menu_pkey");

            entity.ToTable("menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Controlador)
                .HasMaxLength(40)
                .HasColumnName("controlador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(120)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Icono).HasColumnName("icono");
            entity.Property(e => e.Idmenupadre).HasColumnName("idmenupadre");
            entity.Property(e => e.Paginaaction)
                .HasMaxLength(40)
                .HasColumnName("paginaaction");

            entity.HasOne(d => d.IdmenupadreNavigation).WithMany(p => p.InverseIdmenupadreNavigation)
                .HasForeignKey(d => d.Idmenupadre)
                .HasConstraintName("menu_idmenupadre_fkey");
        });

        modelBuilder.Entity<ISLAGO.Entidad.Models.Negocio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("negocio_pkey");

            entity.ToTable("negocio");

            entity.HasIndex(e => e.Numerodocumento, "negocio_numerodocumento_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Imglogo).HasColumnName("imglogo");
            entity.Property(e => e.Nomblogo)
                .HasMaxLength(120)
                .HasColumnName("nomblogo");
            entity.Property(e => e.Nombnegocio)
                .HasMaxLength(100)
                .HasColumnName("nombnegocio");
            entity.Property(e => e.Numerodocumento)
                .HasMaxLength(50)
                .HasColumnName("numerodocumento");
            entity.Property(e => e.Porcentajeimpuestos)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("15.00")
                .HasColumnName("porcentajeimpuestos");
            entity.Property(e => e.Simbolomoneda)
                .HasMaxLength(5)
                .HasDefaultValueSql("'C$'::character varying")
                .HasColumnName("simbolomoneda");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Numerocorrelativo>(entity =>
        {
            entity.HasKey(e => e.Idnumerocorrelativo).HasName("numerocorrelativo_pkey");

            entity.ToTable("numerocorrelativo");

            entity.Property(e => e.Idnumerocorrelativo).HasColumnName("idnumerocorrelativo");
            entity.Property(e => e.Cantidaddigitos).HasColumnName("cantidaddigitos");
            entity.Property(e => e.Fechaactualizacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fechaactualizacion");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .HasColumnName("gestion");
            entity.Property(e => e.Ultimonumero).HasColumnName("ultimonumero");
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

        modelBuilder.Entity<Rolmenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rolmenu_pkey");

            entity.ToTable("rolmenu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Idmenu).HasColumnName("idmenu");
            entity.Property(e => e.Idrol).HasColumnName("idrol");

            entity.HasOne(d => d.IdmenuNavigation).WithMany(p => p.Rolmenus)
                .HasForeignKey(d => d.Idmenu)
                .HasConstraintName("rolmenu_idmenu_fkey");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Rolmenus)
                .HasForeignKey(d => d.Idrol)
                .HasConstraintName("rolmenu_idrol_fkey");
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipo_persona_pkey");

            entity.ToTable("tipo_persona");

            entity.HasIndex(e => e.Tpersona, "tipo_persona_tpersona_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Tpersona)
                .HasMaxLength(20)
                .HasColumnName("tpersona");
        });

        modelBuilder.Entity<Tipodocumentoventum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipodocumentoventa_pkey");

            entity.ToTable("tipodocumentoventa");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(120)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
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
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
