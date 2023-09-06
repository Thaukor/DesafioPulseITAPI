CREATE TABLE Eventos(
	id int identity(1,1) primary key not null,
	titulo varchar(128) not null,
	descripcion nvarchar(128) not null,
	fecha datetime not null,
);

CREATE TABLE Invitados(
	id int identity(1,1) primary key not null,
	email varchar(128) not null,
	asiste bit not null,
	respondio bit not null,
	eventoID int not null,
);

ALTER TABLE Invitados add constraint fk_invitados_eventos foreign key (eventoID) references Eventos (id);