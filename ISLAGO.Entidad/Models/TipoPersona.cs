using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class TipoPersona
{
    public int Id { get; set; }

    public string Tpersona { get; set; } = null!;

    public bool? Estado { get; set; }
}
