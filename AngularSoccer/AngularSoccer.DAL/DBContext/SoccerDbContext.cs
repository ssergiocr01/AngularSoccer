using AngularSoccer.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularSoccer.DAL.DBContext;

public partial class SoccerDbContext : DbContext
{
    public SoccerDbContext()
    {
    }

    public SoccerDbContext(DbContextOptions<SoccerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<GrupoDetalle> GrupoDetalles { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    public virtual DbSet<Prediccion> Prediccions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolMenu> RolMenus { get; set; }

    public virtual DbSet<Torneo> Torneos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("propiedad");
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recurso");
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdEquipo).HasName("PK__Equipo__981ACF534F4955E8");

            entity.ToTable("Equipo");

            entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreLogo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreLogo");
            entity.Property(e => e.UrlLogo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlLogo");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupo__EC597A873FEE49F3");

            entity.ToTable("Grupo");

            entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");
            entity.Property(e => e.IdTorneo).HasColumnName("idTorneo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdTorneoNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdTorneo)
                .HasConstraintName("FK__Grupo__idTorneo__628FA481");
        });

        modelBuilder.Entity<GrupoDetalle>(entity =>
        {
            entity.HasKey(e => e.IdGrupoDetalle).HasName("PK__GrupoDet__3900E111A0A9AEFB");

            entity.ToTable("GrupoDetalle");

            entity.Property(e => e.IdGrupoDetalle).HasColumnName("idGrupoDetalle");
            entity.Property(e => e.DiferenciaDeGoles).HasColumnName("diferenciaDeGoles");
            entity.Property(e => e.GolesAfavor).HasColumnName("golesAFavor");
            entity.Property(e => e.GolesEnContra).HasColumnName("golesEnContra");
            entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");
            entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");
            entity.Property(e => e.PartidosEmpatados).HasColumnName("partidosEmpatados");
            entity.Property(e => e.PartidosGanados).HasColumnName("partidosGanados");
            entity.Property(e => e.PartidosJugados).HasColumnName("partidosJugados");
            entity.Property(e => e.PartidosPerdidos).HasColumnName("partidosPerdidos");
            entity.Property(e => e.Puntos).HasColumnName("puntos");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.GrupoDetalles)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("FK__GrupoDeta__idEqu__656C112C");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.GrupoDetalles)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK__GrupoDeta__idGru__66603565");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF48345B2AA74");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Controlador)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("controlador");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.IdMenuPadre).HasColumnName("idMenuPadre");
            entity.Property(e => e.PaginaAccion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("paginaAccion");

            entity.HasOne(d => d.IdMenuPadreNavigation).WithMany(p => p.InverseIdMenuPadreNavigation)
                .HasForeignKey(d => d.IdMenuPadre)
                .HasConstraintName("FK__Menu__idMenuPadr__4D94879B");
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasKey(e => e.IdPartido).HasName("PK__Partido__552192847709C2CB");

            entity.ToTable("Partido");

            entity.Property(e => e.IdPartido).HasColumnName("idPartido");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaPartido)
                .HasColumnType("datetime")
                .HasColumnName("fechaPartido");
            entity.Property(e => e.FechaPartidoLocal)
                .HasColumnType("datetime")
                .HasColumnName("fechaPartidoLocal");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.GolesLocal).HasColumnName("golesLocal");
            entity.Property(e => e.GolesVisitante).HasColumnName("golesVisitante");
            entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");
            entity.Property(e => e.IdLocal).HasColumnName("idLocal");
            entity.Property(e => e.IdVisitante).HasColumnName("idVisitante");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Partidos)
                .HasForeignKey(d => d.IdGrupo)
                .HasConstraintName("FK__Partido__idGrupo__6B24EA82");

            entity.HasOne(d => d.IdLocalNavigation).WithMany(p => p.PartidoIdLocalNavigations)
                .HasForeignKey(d => d.IdLocal)
                .HasConstraintName("FK__Partido__idLocal__693CA210");

            entity.HasOne(d => d.IdVisitanteNavigation).WithMany(p => p.PartidoIdVisitanteNavigations)
                .HasForeignKey(d => d.IdVisitante)
                .HasConstraintName("FK__Partido__idVisit__6A30C649");
        });

        modelBuilder.Entity<Prediccion>(entity =>
        {
            entity.HasKey(e => e.IdPrediccion).HasName("PK__Predicci__5330367A603A145A");

            entity.ToTable("Prediccion");

            entity.Property(e => e.IdPrediccion).HasColumnName("idPrediccion");
            entity.Property(e => e.GolesLocal).HasColumnName("golesLocal");
            entity.Property(e => e.GolesVisitante).HasColumnName("golesVisitante");
            entity.Property(e => e.IdPartido).HasColumnName("idPartido");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Puntos).HasColumnName("puntos");

            entity.HasOne(d => d.IdPartidoNavigation).WithMany(p => p.Prediccions)
                .HasForeignKey(d => d.IdPartido)
                .HasConstraintName("FK__Prediccio__idPar__787EE5A0");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prediccions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Prediccio__idUsu__797309D9");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F76E6046A5C");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
        });

        modelBuilder.Entity<RolMenu>(entity =>
        {
            entity.HasKey(e => e.IdRolMenu).HasName("PK__RolMenu__CD2045D8C22A612D");

            entity.ToTable("RolMenu");

            entity.Property(e => e.IdRolMenu).HasColumnName("idRolMenu");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__RolMenu__idMenu__5535A963");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__RolMenu__idRol__5441852A");
        });

        modelBuilder.Entity<Torneo>(entity =>
        {
            entity.HasKey(e => e.IdTorneo).HasName("PK__Torneo__58BF3C23A7E08B7C");

            entity.ToTable("Torneo");

            entity.Property(e => e.IdTorneo).HasColumnName("idTorneo");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fechaFin");
            entity.Property(e => e.FechaFinLocal)
                .HasColumnType("datetime")
                .HasColumnName("fechaFinLocal");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fechaInicio");
            entity.Property(e => e.FechaInicioLocal)
                .HasColumnType("datetime")
                .HasColumnName("fechaInicioLocal");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreLogo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreLogo");
            entity.Property(e => e.UrlLogo)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlLogo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6534CF047");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo).HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreFoto");
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("numeroDocumento");
            entity.Property(e => e.Puntos).HasColumnName("puntos");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("urlFoto");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("FK__Usuario__idEquip__74AE54BC");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__73BA3083");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
