using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Numerocorrelativo
{
    public int Idnumerocorrelativo { get; set; }

    public int Ultimonumero { get; set; }

    public int? Cantidaddigitos { get; set; }

    public string Gestion { get; set; } = null!;

    public DateTime? Fechaactualizacion { get; set; }
}
