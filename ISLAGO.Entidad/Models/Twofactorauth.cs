using System;
using System.Collections.Generic;

namespace ISLAGO.Entidad.Models;

public partial class Twofactorauth
{
    public int Id { get; set; }

    public string Token { get; set; } = null!;

    public DateTime Expiracion { get; set; }

    public string Method { get; set; } = null!;

    public int Idusuario { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
