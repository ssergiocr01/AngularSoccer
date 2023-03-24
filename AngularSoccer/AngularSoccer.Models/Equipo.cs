using System;
using System.Collections.Generic;

namespace AngularSoccer.Models;

public partial class Equipo
{
    public int IdEquipo { get; set; }

    public string? Nombre { get; set; }

    public string? UrlLogo { get; set; }

    public string? NombreLogo { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<GrupoDetalle> GrupoDetalles { get; } = new List<GrupoDetalle>();

    public virtual ICollection<Partido> PartidoIdLocalNavigations { get; } = new List<Partido>();

    public virtual ICollection<Partido> PartidoIdVisitanteNavigations { get; } = new List<Partido>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
