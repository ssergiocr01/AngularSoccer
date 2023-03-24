using System;
using System.Collections.Generic;

namespace AngularSoccer.Models;

public partial class Torneo
{
    public int IdTorneo { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaInicioLocal { get; set; }

    public DateTime? FechaFin { get; set; }

    public DateTime? FechaFinLocal { get; set; }

    public string? UrlLogo { get; set; }

    public string? NombreLogo { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>();
}
