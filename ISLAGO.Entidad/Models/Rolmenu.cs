using System;
using System.Collections.Generic;
using ISLAGO.Entidad.Models;

namespace ISLAGO.Entidad.Models;

public partial class Rolmenu
{
    public int Id { get; set; }

    public int? Idrol { get; set; }

    public int? Idmenu { get; set; }

    public bool Estado { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual Menu? IdmenuNavigation { get; set; }

    public virtual Rol? IdrolNavigation { get; set; }
}
