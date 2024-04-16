create database gymmax;
use gymmax;

create table clientes(
id_cliente bigint primary key auto_increment,  
cliente varchar(50),
fecha_nac date
);

create table planes(
id_plan bigint primary key auto_increment,
plan varchar(15),
descripcion varchar(65),
duracion bigint,
precio decimal(15,2)
);

insert into planes values(null, 'Mensualidad', 'Permite hacer ejercicios de fuerza', 30, 450.00);

create table inscripciones(
id_insc bigint primary key auto_increment, 
id_cliente bigint,
id_plan bigint,
fecha_reg date,
fecha_fin date
);

create table usuarios(
id_usuario bigint primary key auto_increment,
usuario varchar(80),
cuenta varchar(40),
clave varchar(255),
nivel bigint,
idioma bigint
);

insert into usuarios values(null, 'Yordi Azael Monreal Zazueta', 'azaelmz', md5("123"), 1, 1);
