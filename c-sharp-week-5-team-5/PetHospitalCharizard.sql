USE master 
GO
DROP DATABASE IF EXISTS PetHospital;
GO
CREATE DATABASE PetHospital;
GO
USE PetHospital;
GO

CREATE TABLE PetOwner (
owner_id int IDENTITY (1,1) PRIMARY KEY,
owner_name nvarchar(666) NOT NULL,
address nvarchar(69) NOT NULL,

);
GO

CREATE TABLE Pet (
pet_id int IDENTITY (1,1) PRIMARY KEY,
pet_name nvarchar(666) NOT NULL,
pet_type nvarchar(69) NOT NULL,
age int NOT NULL,
owner_id int NOT NULL,


CONSTRAINT fk_owner_pet FOREIGN KEY (owner_id) REFERENCES PetOwner (owner_id)
);
GO



CREATE TABLE Invoice (
invoice_line_id int IDENTITY (1,1) PRIMARY KEY,
owner_id int NOT NULL,
amount decimal(5,3) NOT NULL,
hospital_name nvarchar(619) NOT NULL,
invoice_id int NOT NULL,


);
GO

CREATE TABLE Operation (
operation_id int IDENTITY (1,1) PRIMARY KEY,
operation_code char(2)NOT NULL,
description nvarchar(999) NOT NULL,
pet_id int,
date_of_operation datetime2

CONSTRAINT fk_operation_pet FOREIGN KEY (pet_id) REFERENCES Pet (pet_id)
);
GO

CREATE TABLE Pet_Operation(
pet_id int ,
operation_id int

CONSTRAINT pk_Pet_Operation PRIMARY KEY (pet_id, operation_id)
CONSTRAINT fk_pet_id FOREIGN KEY (pet_id) REFERENCES Pet (pet_id),
CONSTRAINT fk_operation_id FOREIGN KEY (operation_id) REFERENCES Operation (operation_id)
);
GO 




INSERT INTO PetOwner (owner_name, address)
VALUES('sam cook', '420 blaze it ave'), ('terry kim', '6969 jimothy st')

INSERT INTO Pet (pet_name, pet_type, age, owner_id)
VALUES ('rover', 'dog', 12, 1), ('spot', 'dog', 2, 2), ('morris', 'cat', 4, 1), ('tweedy', 'bird', 2, 2)
 

INSERT INTO Operation (operation_code, pet_id, description, date_of_operation)
VALUES (01,1, 'rabies vaccine', '20020113'), 
(02, 1, 'examine and treat wound', '20020327'), 
(03, 1, 'heart worm test', '20020402'), 
(04, 2, 'tetanus vaccination', '20010121'), 
(03, 2, 'heart worm test', '20020113'), 
(01, 3, 'rabies vaccination', '20010123'), 
(01, 3, 'rabies vaccination', '20020113'), 
(08, 4, 'Annual Check Up', '20020430'), 
(09, 4, 'Eye Wash', '20020430')

insert into Pet_Operation (pet_id, operation_id)
values(1, 1), (1,2), (1,3), (2,4), (2,5),(3,6),(3,7),(4,8),(4,9)

INSERT INTO Invoice(invoice_id, owner_id, amount, hospital_name)
VALUES (1, 1,  30, 'hiltop hospital'), (1, 1, 24, 'hiltop hospital')

select distinct 
*
from PetOwner o
	 INNER JOIN Pet p ON o.owner_id = p.owner_id
	left outer JOIN Pet_Operation po ON p.pet_id =po.pet_id
	LEFT OUTER JOIN Operation opey ON po.operation_id = opey.operation_id
select
*
from Pet p
	inner join PetOwner o ON p.owner_id = o.owner_id
	left outer join Pet_Operation po ON p.pet_id = po.pet_id
	left outer join Operation op on op.operation_id = po.operation_id
 
select 
	i.hospital_name,
	o.date_of_operation,
	po.owner_name,
	po.address,
	p.pet_name,
	o.description,
	i.amount
from PetOwner po
	inner join Pet p ON po.owner_id = p.owner_id
	inner join Pet_Operation pop ON p.pet_id = pop.pet_id
	inner join Operation o ON pop.operation_id = o.operation_id
	inner join Invoice i ON po.owner_id = i.owner_id
WHERE
	po.owner_name = 'sam cook'



