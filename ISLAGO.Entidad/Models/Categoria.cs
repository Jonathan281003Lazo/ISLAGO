using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombcat { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
}
