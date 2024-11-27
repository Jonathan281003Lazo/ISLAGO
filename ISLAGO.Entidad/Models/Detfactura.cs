using MigracionesBDISLAGO.Models;
using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Detfactura
{
    public int Id { get; set; }

    public int Cantidad { get; set; }

    public float Subtotal { get; set; }

    public float Total { get; set; }

    public float? Pventa { get; set; }

    public float? Descuento { get; set; }

    public string? Garantia { get; set; }

    public bool? Estado { get; set; }

    public int Idfactura { get; set; }

    public int Idarticulo { get; set; }

    public int Idusuario { get; set; }

    public virtual Articulo IdarticuloNavigation { get; set; } = null!;

    public virtual Factura IdfacturaNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
