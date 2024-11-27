using ISLAGO.Entidad.Models;
using System;
using System.Collections.Generic;

namespace MigracionesBDISLAGO.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public int Idempleado { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Detfactura> Detfacturas { get; set; } = new List<Detfactura>();

    public virtual ICollection<Detfacturatmp> Detfacturatmps { get; set; } = new List<Detfacturatmp>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Persona IdempleadoNavigation { get; set; } = null!;

    public virtual ICollection<Twofactorauth> Twofactorauths { get; set; } = new List<Twofactorauth>();
}
