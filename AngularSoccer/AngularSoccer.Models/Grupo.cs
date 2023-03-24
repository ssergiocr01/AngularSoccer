using System;
using System.Collections.Generic;

namespace AngularSoccer.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string? Nombre { get; set; }

    public int? IdTorneo { get; set; }

    public virtual ICollection<GrupoDetalle> GrupoDetalles { get; } = new List<GrupoDetalle>();

    public virtual Torneo? IdTorneoNavigation { get; set; }

    public virtual ICollection<Partido> Partidos { get; } = new List<Partido>();
}
