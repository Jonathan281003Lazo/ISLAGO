using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Menu
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? Idmenupadre { get; set; }

    public string? Icono { get; set; }

    public string? Controlador { get; set; }

    public string? Paginaaction { get; set; }

    public bool Estado { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual Menu? IdmenupadreNavigation { get; set; }

    public virtual ICollection<Menu> InverseIdmenupadreNavigation { get; set; } = new List<Menu>();

    public virtual ICollection<Rolmenu> Rolmenus { get; set; } = new List<Rolmenu>();
}
