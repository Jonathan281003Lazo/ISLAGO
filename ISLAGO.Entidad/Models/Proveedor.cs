using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombnegocio { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
}
