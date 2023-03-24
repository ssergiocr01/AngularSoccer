using System;
using System.Collections.Generic;

namespace AngularSoccer.Models;

public partial class Partido
{
    public int IdPartido { get; set; }

    public DateTime? FechaPartido { get; set; }

    public DateTime? FechaPartidoLocal { get; set; }

    public int? IdLocal { get; set; }

    public int? IdVisitante { get; set; }

    public int? GolesLocal { get; set; }

    public int? GolesVisitante { get; set; }

    public int? IdGrupo { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }

    public virtual Equipo? IdLocalNavigation { get; set; }

    public virtual Equipo? IdVisitanteNavigation { get; set; }

    public virtual ICollection<Prediccion> Prediccions { get; } = new List<Prediccion>();
}
