using ISLAGO.Entidad.Models;
using System;
using System.Collections.Generic;

namespace MigracionesBDISLAGO.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Nombrol { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
