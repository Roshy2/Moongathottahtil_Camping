create database  db_camp collate utf8_general_ci;
use db_camp;

create table camp(
	id int not null auto_increment,
    vorname varchar(100) not null,
    nachname varchar(100) not null,
    von date not null,
    bis date not null,
    geburtsdatum date null,
    strasse varchar(100) not null ,
    plz int not null,
    ort varchar(100) not null ,
    telefonnummer int  null,
    email varchar(100) not null ,
    reservierplatz Varchar(100) not null,
    
    constraint id_PK primary key(id)
)engine=InnoDB;

INSERT INTO camp VAlUES(null, "Roshy", "Moongathottathil", '2020-04-01', '2020-04-14','2000-03-14', "Hansstraße ", 6020, "Völs", null,"romo@gmail.com", "Klenovica");

select * from camp