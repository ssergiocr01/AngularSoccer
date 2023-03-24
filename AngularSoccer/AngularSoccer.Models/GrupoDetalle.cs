using System;
using System.Collections.Generic;

namespace AngularSoccer.Models;

public partial class GrupoDetalle
{
    public int IdGrupoDetalle { get; set; }

    public int? IdEquipo { get; set; }

    public int? IdGrupo { get; set; }

    public int? PartidosJugados { get; set; }

    public int? PartidosGanados { get; set; }

    public int? PartidosEmpatados { get; set; }

    public int? PartidosPerdidos { get; set; }

    public int? Puntos { get; set; }

    public int? GolesAfavor { get; set; }

    public int? GolesEnContra { get; set; }

    public int? DiferenciaDeGoles { get; set; }

    public virtual Equipo? IdEquipoNavigation { get; set; }

    public virtual Grupo? IdGrupoNavigation { get; set; }
}
