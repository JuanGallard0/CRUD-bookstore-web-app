-- Tabla rol
create table rol (
	idrol integer primary key identity,
	nombre varchar(50) not null unique,
	descripcion varchar(255) not null,
	estado bit default(1)
);
go

-- Tabla persona
create table persona (
	idpersona integer primary key identity,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	edad integer not null,
	telefono varchar(20) not null,
	idrol integer not null,
	FOREIGN KEY (idrol) REFERENCES rol(idrol) ON DELETE CASCADE
);
go

-- Tabla pelicula
create table pelicula (
	nombre varchar(50) primary key,
	fecha datetime not null,
	duracion time not null,
	clasificacion varchar(1) not null,
	estudio varchar(50) not null,
	director varchar(50) not null,
	genero varchar(50) null
);

-- Tabla acceso_premier
create table acceso_premier (
	idapremier integer primary key identity,
	nombre_pelicula varchar(50) not null,
	idpersona integer not null,
	FOREIGN KEY (nombre_pelicula) REFERENCES pelicula(nombre) ON DELETE CASCADE,
	FOREIGN KEY (idpersona) REFERENCES persona(idpersona) ON DELETE CASCADE
);
go

-- Insertar roles
insert into rol (
	nombre,
	descripcion,
	estado
) values 
	('Owner', 'Members of the db_owner fixed database role can perform all configuration and maintenance activities on the database, and can also drop the database in SQL Server.', 1), 
	('Administrator', 'Members of the db_securityadmin fixed database role can modify role membership for custom roles only and manage permissions.', 1),
	('Operator', 'Members of these database roles can administer and use the data collector.', 1);
go

-- Insertar personas
insert into persona (
	nombre,
	apellido,
	edad,
	telefono,
	idrol
) values 
	('Juan', 'Gallardo', 26, 2222222, 1), 
	('Marco', 'Fabrizzio', 29, 3333333, 2), 
	('Daniel', 'Hernandez', 35, 4444444, 3);
go

-- Insertar peliculas
insert into pelicula (
	nombre,
	fecha,
	duracion,
	clasificacion,
	estudio,
	director,
	genero
) values 
	('The Wolf of Wall Street', '2021-05-28 14:00:00', '03:00:00', 'D', 'Paramount', 'Martin Scorsese', 'Crime, Drama, Biography'),
	('Jurassic Park', '2021-06-02 09:30:00', '02:07:00', 'B', 'Universal', 'Steven Spielberg', 'Action, Adventure, Sci-Fi');
go	