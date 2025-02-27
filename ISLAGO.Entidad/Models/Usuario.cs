using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public bool? Estado { get; set; }

    public int? IdRol { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Detfactura> Detfacturas { get; set; } = new List<Detfactura>();

    public virtual ICollection<Detfacturatmp> Detfacturatmps { get; set; } = new List<Detfacturatmp>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Twofactorauth> Twofactorauths { get; set; } = new List<Twofactorauth>();
}
