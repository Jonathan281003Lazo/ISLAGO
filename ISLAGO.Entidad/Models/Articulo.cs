using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Articulo
{
    public int Id { get; set; }

    public string Nombart { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime Fechaingreso { get; set; }

    public DateTime? Fechavencimiento { get; set; }

    public string Umedidas { get; set; } = null!;

    public float Pcompra { get; set; }

    public float Pventa { get; set; }

    public float Impuestos { get; set; }

    public int? Existencia { get; set; }

    public string Imagen { get; set; } = null!;

    public bool? Estado { get; set; }

    public int Idproveedor { get; set; }

    public int Idcategoria { get; set; }

    public string? CodigoBarra { get; set; }

    public virtual ICollection<Detfactura> Detfacturas { get; set; } = new List<Detfactura>();

    public virtual ICollection<Detfacturatmp> Detfacturatmps { get; set; } = new List<Detfacturatmp>();

    public virtual Categoria IdcategoriaNavigation { get; set; } = null!;

    public virtual Proveedor IdproveedorNavigation { get; set; } = null!;
}
