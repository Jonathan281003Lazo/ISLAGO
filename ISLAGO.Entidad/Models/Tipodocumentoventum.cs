using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Tipodocumentoventum
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
