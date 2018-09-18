CREATE TABLE States(
StateId int Identity(1,1),
StateName varchar (50),
PRIMARY KEY (StateId)
);

CREATE TABLE City(
CityId int Identity(1,1),
CityName varchar (50),
StateId int
PRIMARY KEY (CityId),
FOREIGN KEY(StateId) REFERENCES States(StateId)
);

CREATE TABLE Constituency (
ConstituencyId int Identity(1,1),
ConstituencyName varchar (50),
CityId int
PRIMARY KEY (ConstituencyId),
FOREIGN KEY(CityId) REFERENCES City(CityId)
);

CREATE TABLE WardNo (
WardNumberId int Identity (1,1),
WardNumber varchar(50),
ConstituencyId int
PRIMARY KEY (WardNumberId),
FOREIGN KEY(ConstituencyId) REFERENCES Constituency(ConstituencyId)
);

--Saving in MyDotnetDataBase

CREATE TABLE VoterEnrollment(
EnrollmentId int Identity(1,1),
StateId int,
CityId int,
ConstituencyId int,
WardNumberId int,
EnrollerName varchar(100),
FatherName varchar(100),
DOB date,
Email varchar(100),
PhoneNumber varchar(20),
DateCreated datetime,
EnrollmentNumber varchar(50),
PRIMARY KEY (EnrollmentId),
FOREIGN KEY(StateId) REFERENCES States(StateId),
FOREIGN KEY(CityId) REFERENCES City(CityId),
FOREIGN KEY(ConstituencyId) REFERENCES Constituency(ConstituencyId),
FOREIGN KEY(WardNumberId) REFERENCES WardNo(WardNumberId),
);

Truncate Table States
Truncate table  City
Truncate table Constituency

drop table City


Insert into States values('UP')
Insert into States values('Haryana')
Insert into States values('Bihar')

insert into City values('Allahabad',1)
insert into City values('Noida',1)
insert into City values('Ghaziabad',1)
insert into City values('Rohtak',2)
insert into City values('Gurgaon',2)
insert into City values('Hisar',2)
insert into City values('Patna',2)
insert into City values('Sitamarhi',2)
insert into City values('Darbhanga',2)

insert into Constituency values('Agnipath',1)
insert into Constituency values('Civil Lines',1)
insert into Constituency values('Chowk',1)
insert into Constituency values('karali',2)
insert into Constituency values('Nagina',3)
insert into Constituency values('naini',4)
insert into Constituency values('Bairana',5)
insert into Constituency values('Manhohan Park',6)
insert into Constituency values('Shankar Chowk',7)
insert into Constituency values('Rajiv Chowk',8)
insert into Constituency values('Dara Ganj',9)

insert into WardNo values('Ward #1', 1)
insert into WardNo values('Ward #2', 2)
insert into WardNo values('Ward #3', 3)
insert into WardNo values('Ward #4', 4)
insert into WardNo values('Ward #5', 5)
insert into WardNo values('Ward #6', 6)
insert into WardNo values('Ward #7', 7)
insert into WardNo values('Ward #8', 8)
insert into WardNo values('Ward #9', 9)
insert into WardNo values('Ward #10', 10)
insert into WardNo values('Ward #11', 11)

insert into WardNo values('Ward #1', 1)
insert into WardNo values('Ward #1', 1)
insert into WardNo values('Ward #1', 1)
insert into WardNo values('Ward #1', 1)
insert into WardNo values('Ward #1', 1)





NotMapped attribute can be applied to properties of an entity class for which we do not want to create corresponding columns in the database. By default, EF creates a column for each property (must have get; & set;) in an entity class. The [NotMapped] attribute overrides this default convention.

Serialization is the process of converting an object into a stream of bytes to store the object or transmit it to memory, a database, or a file. Its main purpose is to save the state of an object in order to be able to recreate it when needed. The reverse process is called deserialization.