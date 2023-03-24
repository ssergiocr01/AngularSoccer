using System;
using System.Collections.Generic;

namespace AngularSoccer.Models;

public partial class Prediccion
{
    public int IdPrediccion { get; set; }

    public int? IdPartido { get; set; }

    public int? IdUsuario { get; set; }

    public int? GolesLocal { get; set; }

    public int? GolesVisitante { get; set; }

    public int? Puntos { get; set; }

    public virtual Partido? IdPartidoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
