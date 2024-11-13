using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public int Idrol { get; set; }

    public int Idempleado { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Detfactura> Detfacturas { get; set; } = new List<Detfactura>();

    public virtual ICollection<Detfacturatmp> Detfacturatmps { get; set; } = new List<Detfacturatmp>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Empleado IdempleadoNavigation { get; set; } = null!;

    public virtual Rol IdrolNavigation { get; set; } = null!;

    public virtual ICollection<Twofactorauth> Twofactorauths { get; set; } = new List<Twofactorauth>();
}
