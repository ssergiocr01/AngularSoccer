create table Menu(
idMenu int primary key identity(1,1),
descripcion varchar(30),
idMenuPadre int references Menu(idMenu),
icono varchar(30),
controlador varchar(30),
paginaAccion varchar(30),
esActivo bit,
fechaRegistro datetime default getdate()
)

go

create table Rol(
idRol int primary key identity(1,1),
descripcion varchar(30),
esActivo bit,
fechaRegistro datetime default getdate()
)

go
 
 create table RolMenu(
 idRolMenu int primary key identity(1,1),
 idRol int references Rol(idRol),
 idMenu int references Menu(idMenu),
 esActivo bit,
 fechaRegistro datetime default getdate()
 )

go

create table Usuario(
idUsuario int primary key identity(1,1),
nombre varchar(50),
correo varchar(50),
telefono varchar(50),
idRol int references Rol(idRol),
urlFoto varchar(500),
nombreFoto varchar(100),
clave varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)

go

create table Equipo(
idEquipo int primary key identity(1,1),
nombre varchar(50),
urlLogo varchar(500),
nombreLogo varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)

go

create table Torneo(
idTorneo int primary key identity(1,1),
nombre varchar(100),
fechaInicio datetime,
fechaInicioLocal datetime,
fechaFin datetime,
fechaFinLocal datetime,
urlLogo varchar(500),
nombreLogo varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)

go

create table Grupo(
idGrupo int primary key identity(1,1),
nombre varchar(50),
idTorneo int references Torneo(idTorneo)
)

go

create table GrupoDetalle(
idGrupoDetalle int primary key identity(1,1),
idEquipo int references Equipo(idEquipo),
idGrupo int references Grupo(idGrupo),
partidosJugados int,
partidosGanados int,
partidosEmpatados int,
partidosPerdidos int,
puntos int,
golesAFavor int,
golesEnContra int,
diferenciaDeGoles int
)

go

create table Partido(
idPartido int primary key identity(1,1),
fechaPartido datetime,
fechaPartidoLocal datetime,
idLocal int references Equipo(idEquipo),
idVisitante int references Equipo(idEquipo),
golesLocal int,
golesVisitante int,
idGrupo int references Grupo(idGrupo),
esActivo bit,
fechaRegistro datetime default getdate()
)

go

create table Prediccion(
idPrediccion int primary key identity(1,1),
idPartido int references Partido(idPartido),
idUsuario int references Usuario(idUsuario),
golesLocal int,
golesVisitante int,
puntos int
)

go

create table Configuracion(
recurso varchar(50),
propiedad varchar(50),
valor varchar(60)
)