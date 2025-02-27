using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string Primernombre { get; set; } = null!;

    public string Segundonombre { get; set; } = null!;

    public string Primerapellido { get; set; } = null!;

    public string Segundoapellido { get; set; } = null!;

    public DateTime Fechanac { get; set; }

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public bool? Estado { get; set; }

    public int IdRol { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
