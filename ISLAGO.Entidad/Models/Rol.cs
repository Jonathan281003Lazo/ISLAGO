using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Nombrol { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
