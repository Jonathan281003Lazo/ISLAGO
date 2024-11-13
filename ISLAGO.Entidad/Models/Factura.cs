using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Factura
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public string Nombcliente { get; set; } = null!;

    public float Total { get; set; }

    public bool? Anulada { get; set; }

    public bool? Estado { get; set; }

    public int Idusuario { get; set; }

    public virtual ICollection<Detfactura> Detfacturas { get; set; } = new List<Detfactura>();

    public virtual ICollection<Detfacturatmp> Detfacturatmps { get; set; } = new List<Detfacturatmp>();

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
