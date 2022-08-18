USE master
GO

-- Drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

-- Create Tables

CREATE TABLE potholes (
	pothole_id int IDENTITY(1000,1) NOT NULL,
	severity int check (severity between 0 and 3) DEFAULT 0,
	latitude varchar(25),
	longitude varchar(25),
	address varchar(150),
	city varchar(75),
	CONSTRAINT PK_potholes PRIMARY KEY (pothole_id)
)

CREATE TABLE reports (
	report_id int IDENTITY(2000,1) NOT NULL,
	pothole_id int NOT NULL,
	report_date date,
	is_Reviewed BIT,
	report_notes varchar(300),
	CONSTRAINT PK_reports PRIMARY KEY (report_id),
	CONSTRAINT [FK_reports_potholes] FOREIGN KEY (pothole_id) REFERENCES [potholes] (pothole_id),
)

CREATE TABLE inspections (
	inspection_id int IDENTITY(3000,1) NOT NULL,
	pothole_id int NOT NULL,
	inspection_date date,
	is_Inspected BIT,
	inspection_notes varchar(300),
	CONSTRAINT PK_inspections PRIMARY KEY (inspection_id),
	CONSTRAINT [FK_inspections_potholes] FOREIGN KEY (pothole_id) REFERENCES [potholes] (pothole_id),
)

CREATE TABLE repairs (
	repair_id int IDENTITY(4000,1) NOT NULL,
	pothole_id int NOT NULL,
	repair_date date,
	is_Repaired BIT,
	repair_notes varchar(300),
	CONSTRAINT PK_repairs PRIMARY KEY (repair_id),
	CONSTRAINT [FK_repairs_potholes] FOREIGN KEY (pothole_id) REFERENCES [potholes] (pothole_id),
)

CREATE TABLE users (
	user_id int IDENTITY(5000,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

-- Populate default data for testing: user and admin with password of 'password'
-- These values should not be kept when going to Production
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('jimothy','yZTP3HjGnpELdELpsS2YsM1e0z0=', 'R+IFi2NICls=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('testuser','lGCwMrq2x7PPlCdI4FHSULskiJ4=','/93YdmNM1lU=','user');




INSERT INTO potholes (latitude, longitude, address, city)
VALUES ('39.998159','-83.042176','1256-1280 Kinnear Rd', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1000, '8/9/2022', 0, 'No notes at this time');

INSERT INTO potholes (latitude, longitude, address, city)
VALUES ('39.975428','-83.003223','High & Russell', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1001, '8/9/2022', 0, 'This one is a doozy, folks');

INSERT INTO potholes (latitude, longitude, address, city)
VALUES ('40.146961','-82.911106','7165-7151 Hilmar Dr', 'Westerville');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1002, '8/11/2022', 0, 'woohoo');

INSERT INTO potholes (latitude, longitude, address, city, severity)
VALUES ('40.146961','-82.88546204566956','982 Elaine Road', 'Whitehall',2);
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1003, '8/7/2022', 1, 'woohoo');
INSERT INTO inspections (pothole_id, inspection_date,is_Inspected)
VALUES (1003,'8/11/2022',1);
INSERT INTO repairs (pothole_id, repair_date, is_Repaired)
VALUES (1003,'8/18/2022',1);

INSERT INTO potholes (latitude, longitude, address, city)
VALUES ('40.062202491618244','-83.01505565643312','155 Morse Road', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1004, '7/30/2022', 1, '');
INSERT INTO inspections (pothole_id, inspection_date, is_Inspected, inspection_notes)
VALUES (1004, '8/20/2022', 0, '');

INSERT INTO potholes (latitude, longitude, address, city, severity)
VALUES ('40.01729173288799','-82.84554004669191','5983 Havens Corners Road', 'Gahanna', 1);
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1005, '8/12/2022', 1, '');
INSERT INTO inspections (pothole_id, inspection_date,is_Inspected)
VALUES (1005,'8/22/2022', 1);
INSERT INTO repairs (pothole_id, repair_date, is_Repaired, repair_notes)
VALUES (1005, '8/29/2022', 0, '');

INSERT INTO potholes (latitude, longitude, address, city)
VALUES ('39.964071395856465','-82.99672327851772','153 East Gay Street', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1006, '8/15/2022', 1, '4 miles deep');
INSERT INTO inspections (pothole_id, inspection_date, is_Inspected, inspection_notes)
VALUES (1006, '8/20/2022', 0, '');

INSERT INTO potholes (latitude, longitude, address, city, severity)
VALUES ('39.97816743920749','-83.00374300220207','Torso Menswear', 'Columbus', 3);
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1007, '8/1/2022', 1, 'Took out 3 grandmas');
INSERT INTO inspections (pothole_id, inspection_date,is_Inspected)
VALUES (1007,'8/5/2022', 1);
INSERT INTO repairs (pothole_id, repair_date, is_Repaired, repair_notes)
VALUES (1007, '8/29/2022', 0, '');

INSERT INTO potholes (latitude, longitude, address, city, severity)
VALUES ('39.998970880629365','-83.05739593924955','1830 Waltham Road', 'Upper Arlington', 1);
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1008, '8/1/2022', 1, '8 cars have mysteriously disappeared near this hole');
INSERT INTO inspections (pothole_id, inspection_date,is_Inspected)
VALUES (1008,'8/15/2022', 1);
INSERT INTO repairs (pothole_id, repair_date, is_Repaired)
VALUES (1008, '8/18/2022', 1);

INSERT INTO potholes (latitude, longitude, address, city)
VALUES ('40.06393300018343','-83.01939356077217','5015 North High Street', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1009, '8/14/2022', 1, 'woohoo2');
INSERT INTO inspections (pothole_id, inspection_date, is_Inspected)
VALUES (1009, '8/15/2022', 0);


INSERT INTO potholes (latitude, longitude, address, city, severity) 
VALUES ('39.958435561526166','-83.03017710851982','1115 West Broad Street', 'Columbus', 2);
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes) 
VALUES (1010, '8/14/2022', 1, 'woohoo');
INSERT INTO inspections (pothole_id, inspection_date, is_Inspected)
VALUES (1010, '8/16/2022', 1);
INSERT INTO repairs (pothole_id, repair_date, is_Repaired)
VALUES (1010, '8/16/2022', 1);

INSERT INTO potholes (latitude, longitude, address, city, severity) 
VALUES ('39.915553886571054','-82.88064779054692','Hamilton Road', 'Columbus', 3);
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes) 
VALUES (1011, '8/10/2022', 1, 'woohoo');
INSERT INTO inspections (pothole_id, inspection_date, is_Inspected)
VALUES (1011, '8/12/2022', 1);
INSERT INTO repairs (pothole_id, repair_date, is_Repaired)
VALUES (1011, '8/15/2022', 0);

INSERT INTO potholes (latitude, longitude, address, city)
VALUES ('39.964633336643146','-82.95989334583284','101 Franklin Park West', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1012, '8/18/2022', 1, 'sah dude');
INSERT INTO inspections (pothole_id, inspection_date, is_Inspected, inspection_notes)
VALUES (1012, '8/20/2022', 0, 'none');

INSERT INTO potholes (severity, latitude, longitude, address, city)
VALUES (3, '40.0080847855316','-83.0026960372925','2200 Indianola Avenue', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1013, '8/16/2022', 1, 'hey hey');
INSERT INTO inspections (pothole_id, inspection_date, is_Inspected, inspection_notes)
VALUES (1013, '8/18/2022', 1, 'none');
INSERT INTO repairs (pothole_id, repair_date, is_Repaired, repair_notes)
VALUES (1013, '8/27/22', 0, 'not yet bro');

INSERT INTO potholes (severity, latitude, longitude, address, city)
VALUES (2, '40.00179441058047','-83.0141866207123','209 W. 18th Avenue', 'Columbus');
INSERT INTO reports (pothole_id, report_date, is_Reviewed, report_notes)
VALUES (1014, '8/12/2022', 1, 'hey hey');
INSERT INTO inspections (pothole_id, inspection_date, is_Inspected, inspection_notes)
VALUES (1014, '8/15/2022', 1, 'none');
INSERT INTO repairs (pothole_id, repair_date, is_Repaired, repair_notes)
VALUES (1014, '8/18/22', 1, 'doneskis');

<<<<<<< HEAD


=======
>>>>>>> 951093562eff9f76053c900efc06e447ad9882bc
select * from potholes
select * from reports
select * from inspections
select * from repairs
select * from users

GO