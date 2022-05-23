create database Knjizara

use Knjizara

create table Magacin
(
id int primary key identity(1,1),
naziv nvarchar(50),
adresa nvarchar(50)
)

create table Autor
(
id int primary key identity(1,1),
ime nvarchar(20),
prezime nvarchar(20)
)

create table Zanr
(
id int primary key identity(1,1),
naziv nvarchar(30) not null
)

create table Knjiga
(
id int primary key identity(1,1),
naziv nvarchar(20),
autorID nvarchar(50),
)

create table KnjigaZanr
(
id int primary key identity(1,1),
knjigaID int not null,
zanrID int not null
)

create table KnjigaMagacin
(
id int primary key identity(1,1),
knjigaID int not null,
magacinID int not null,
kolicina int,
cena money,
check (kolicina > -1)
)

create table Osoba
(
id int primary key identity(1,1),
ime nvarchar(20),
prezime nvarchar(30),
username nvarchar(20) unique,
pass nvarchar(20),
uloga int
)

create table FakturaH
(
id int primary key identity(1,1),
osobaID int,
ukupna_cena money,
datum datetime
)

create table FakturaB
(
id int primary key identity(1,1),
fakturaHid int,
knjigamagacinID int not null,
kolicina int,
)

create table Nestalo
(
id int primary key identity(1,1),
knjigamagacinID int,
kolicina int,
datum datetime
)

create table OsobaMagacin
(
id int primary key identity (1,1),
osobaID int not null,
magacinID int not null
)

go

create view Stanje as
select KnjigaMagacin.id, Knjiga.naziv, ime + ' ' + prezime 'autor', kolicina, cena from KnjigaMagacin
join Knjiga on knjigaID = Knjiga.id
join Magacin on magacinID = Magacin.id
join Autor on Autor.id = autorID


go

create trigger prodato
on FakturaB
for insert
as
begin
begin try
begin transaction

update KnjigaMagacin
set kolicina = KnjigaMagacin.kolicina - inserted.kolicina
from KnjigaMagacin
join inserted on inserted.knjigamagacinID = KnjigaMagacin.id 

insert into FakturaB (knjigamagacinID, kolicina, fakturaHid) select knjigamagacinID, kolicina, fakturaHid from inserted

commit transaction

end try
begin catch

rollback transaction

end catch

end

go

create trigger promenjeno
on KnjigaMagacin
after update
as
begin
begin transaction

begin try

insert into Nestalo select inserted.id,deleted.kolicina - inserted.kolicina, GETDATE()  from inserted
join deleted on deleted.id = inserted.id
where deleted.kolicina - inserted.kolicina != 0

commit transaction

end try

begin catch
rollback transaction
end catch

end


insert into Osoba values ('admin', 'admin', 'admin', '1234', 2)