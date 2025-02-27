using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Negocio
{
    public int Id { get; set; }

    public string? Imglogo { get; set; }

    public string? Nomblogo { get; set; }

    public string Numerodocumento { get; set; } = null!;

    public string Nombnegocio { get; set; } = null!;

    public string? Correo { get; set; }

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public decimal Porcentajeimpuestos { get; set; }

    public string Simbolomoneda { get; set; } = null!;
}
